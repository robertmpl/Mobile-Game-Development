using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{

    public GameObject heart;

    [Header("Settings")]
    public float health = 10f; // Health of the slime
    public float score = 10f; // Score that is added when this slime is slain
    public float moveCooldown = 1f; // Time in seconds between each movement
    public float moveStrength = 10f; // How much the slime moves on each opportunity

    public bool shootsProjectiles = false;
    public bool omnidirectionalShooting = false;
    public float projectileFireRate = 4f;
    public float projectileSpeed = 1f;
    public GameObject projectile;

    public ParticleSystem deathParticles;
    public AudioClip projectileSound;
    public AudioClip hitSound;
    public AudioClip deathSound;

    GameObject player;
    Animator animator;
    GameObject gameManager;

    Vector2[] directions;
    float nextShotTime;
    float nextMove;
    bool canTakeDamage = true;
    void Start()
    {
        directions = new Vector2[]
        {
            Vector2.up, // north
            (Vector2.up + Vector2.right), // north east
            Vector2.right, // east
            (Vector2.down + Vector2.right), // south east
            Vector2.down, // south
            (Vector2.down + Vector2.left), // south west
            Vector2.left, // west
            (Vector2.up + Vector2.left) // north west
        };

        gameManager = GameObject.Find("GameManager");

        player = GameObject.Find("Knight"); // Get the player object in the scene for attacking and movement
        animator = GetComponent<Animator>(); // Get animator for animation transitions

        nextShotTime = Time.time + nextShotTime; // Prevent enemy from instantly shooting
        nextMove = Time.time + moveCooldown; // Set initial next movement opportunity
    }

    void Update()
    {
        MoveTowardsPlayer();

        ShootProjectiles();
    }
    Vector2 GetPlayerVector()
    {
        Vector3 vector = player.transform.position - transform.position; // Get vector to player from slime
        vector = vector.normalized; // Normalise the vector to prevent moving different distances at different ranges

        return vector;
    }

    void MoveTowardsPlayer()
    {
        if (Time.time >= nextMove) // If enough time has passed for next movement opportunity
        {
            if (player) // Check if player exists
            {
                nextMove = Time.time + moveCooldown;

                Vector2 vector = GetPlayerVector();

                GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                GetComponent<Rigidbody2D>().linearVelocity = vector * moveStrength; // Apply velocity with the vector to move towards the player
            }

        };

        if (Time.time >= (nextMove - 0.3f))
        {
            animator.SetBool("IsJumping", true);
        }
    }
    void ShootProjectiles()
    {
        if (Time.time >= nextShotTime)
        {
            if (shootsProjectiles) // If the slime can shoot projectiles
            {
                nextShotTime = Time.time + projectileFireRate;

                AudioSource.PlayClipAtPoint(projectileSound, transform.position);

                if (omnidirectionalShooting)
                {
                    for (int i = 0; i < directions.Length; i++) // For each direction in the directions table
                    {
                        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
                        newProjectile.GetComponent<Rigidbody2D>().linearVelocity = directions[i] * projectileSpeed; // Fire the projectile in a direction

                        StartCoroutine(DeleteProjectile(newProjectile)); // Deletes projectile after some time without yielding
                    }
                }
                else
                {
                    Vector2 vector = GetPlayerVector(); // Get player direction

                    GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity); // Create new projectile
                    newProjectile.GetComponent<Rigidbody2D>().linearVelocity = vector * projectileSpeed; // Send projectile in player direction

                    float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg; // Get the angle of the shot projectile direction
                    newProjectile.transform.rotation = Quaternion.Euler(0f, 0f, angle); // Make projectile face in the direction angle

                    StartCoroutine(DeleteProjectile(newProjectile));
                }
            }
        }
    }

    private IEnumerator DeleteProjectile(GameObject bullet)
    {
        yield return new WaitForSeconds(5f);

        Destroy(bullet);
    }

    public void DealDamage(float damage) // Expose function for other scripts to be able to deal damage to the slime
    {
        if (canTakeDamage)
        {
            health -= damage; // Take damage away from health

            AudioSource.PlayClipAtPoint(hitSound, transform.position);

            if (health <= 0f) // If no more health remaining
            {
                canTakeDamage = false;

                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                
                ParticleSystem newParticles = Instantiate(deathParticles, transform.position, Quaternion.identity);

                newParticles.startColor = GetComponent<SpriteRenderer>().color;

                ScoreHandler handleScore = gameManager.GetComponent<ScoreHandler>();
                WaveHandler handleWave = gameManager.GetComponent<WaveHandler>();

                int randomNumber = Random.Range(0, 100); // Generate a number

                if (randomNumber <= 5) // Number is equal to the percentage chance
                {
                    Instantiate(heart, transform.position, Quaternion.identity);
                }

                handleWave.decreaseEnemyCount();
                handleScore.AddScore(score); // Add score

                Destroy(gameObject); // Destroy the slime
            }
        }
    }
}
