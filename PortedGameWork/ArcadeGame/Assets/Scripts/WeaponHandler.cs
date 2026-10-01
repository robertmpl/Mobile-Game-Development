using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [Header("Settings")]
    public float damage = 5f;

    GameObject player;
    PlayerShoot shoot;

    bool homingWeapon = false;
    float weaponSpeed = 2;
    void Start()
    {
        // Get variables from other scripts
        player = GameObject.Find("Knight");
        shoot = player.GetComponent<PlayerShoot>();
        homingWeapon = shoot.homingWeapon;
        weaponSpeed = shoot.weaponSpeed;
    }

    void Update()
    {
        if (homingWeapon) // If the homing weapon has been unlocked
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Get list of all enemies currently in scene

            // Create variables
            GameObject nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemies) // Loop through ever enemy in the scene
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position); // Get distance to enemy

                if (distance < nearestDistance) // If the distance to queryed enemy is closer than the nearest distance found
                {
                    nearestDistance = distance; // Set new nearest distance
                    nearestEnemy = enemy; // Set new nearest enemy
                }
            }

            if (nearestEnemy != null) // If an enemy exists
            {
                Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized; // Get direction to enemy

                GetComponent<Rigidbody2D>().linearVelocity = direction * weaponSpeed; // Apply velocity in the enemies direction, as this is every frame, it acts like homing
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Check if an enemy has been hit
        {
            Destroy(gameObject); // Destroy the weapon

            SlimeBehaviour slime = collision.gameObject.GetComponent<SlimeBehaviour>(); // Get the individual slimes code

            slime.DealDamage(damage * shoot.weaponDamageMultiplier); // Use the weapons damage against the enemy
        }
    }
}
