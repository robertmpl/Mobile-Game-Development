using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gameOverPanel;

    [Header("Sprites")]
    public UnityEngine.UI.Image healthImage;
    public Sprite[] healthSprites;

    [Header("Settings")]
    public int health = 13;
    public int damageCooldown = 1;
    public AudioClip hurtSound;

    float nextDamageTime;

    void Start()
    {
        nextDamageTime = Time.time;
    }

    void Update()
    {
        if (health >= 0 && health < 14) // Check if health is in valid range
        {
            healthImage.sprite = healthSprites[health];  // Set image based on health number
        }

        if (Time.time < nextDamageTime) // Visual indicator of invincibility
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile")) // Check if the collision is with an enemy or projectile
        {
            if (collision.gameObject.CompareTag("Projectile")) // Check for projectile
            {
                Destroy(collision.gameObject); // Remove projectile
            }

            if (health > 0 && Time.time >= nextDamageTime) // Check if player can take damage
            {
                nextDamageTime = Time.time + damageCooldown; // Set cooldown (invincibility frames)
                health -= 2; // Remove a health point

                AudioSource.PlayClipAtPoint(hurtSound, transform.position);

                if (health <= 0) // If player has no more health remaining
                {
                    healthImage.sprite = healthSprites[0]; // Set health bar to empty
                    gameObject.SetActive(false); // Deactivate the player
                    gameOverPanel.SetActive(true); // Show game over screen
                }
            }
        }
    }
    public void addHealth(int amount)
    {
        if (health < 13) // If health is less than the maximum
        {
            health += amount;
        }
    }

}
