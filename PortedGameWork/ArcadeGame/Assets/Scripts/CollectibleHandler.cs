using Unity.VisualScripting;
using UnityEngine;

public class CollectibleHandler : MonoBehaviour
{

    PlayerShoot shoot;
    NotificationHandler notification;
    PlayerHealth health;

    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { // Check if the player is the collision

            // Get other scripts to use their functions
            GameObject player = collision.gameObject;
            health = player.GetComponent<PlayerHealth>();
            shoot = player.GetComponent<PlayerShoot>();
            notification = GameObject.Find("GameManager").GetComponent<NotificationHandler>();

            AudioSource.PlayClipAtPoint(sound, transform.position);

            if (gameObject.CompareTag("Heart")) // Check for the item using tags
            {
                pickupHeart(collision);
            }

            if (gameObject.CompareTag("Chocolate")) 
            {
                pickupChocolate(collision);
            }

            if (gameObject.CompareTag("Chicken"))
            {
                pickupChicken(collision);
            }

            if (gameObject.CompareTag("Carrot"))
            {
                pickupCarrot(collision);
            }

            if (gameObject.CompareTag("Magnet"))
            {
                pickupMagnet(collision);
            }
        }
    }

    void pickupHeart(Collider2D collision)
    {
        GameObject player = collision.gameObject;

        health.addHealth(2);

        Destroy(gameObject);
    }

    void pickupChocolate(Collider2D collision)
    {
        shoot.weaponFireRate = shoot.weaponFireRate - 0.05f;

        notification.CreateNotification("Chocolate, -0.05 Fire Rate", GetComponent<SpriteRenderer>().sprite);

        Destroy(gameObject);
    }
    void pickupChicken(Collider2D collision)
    {
        shoot.weaponDamageMultiplier = shoot.weaponDamageMultiplier + 0.1f;

        notification.CreateNotification("Chicken, +0.1x Damage Multiplier", GetComponent<SpriteRenderer>().sprite);

        Destroy(gameObject);
    }

    void pickupCarrot(Collider2D collision)
    {
        shoot.weaponSpeed = shoot.weaponSpeed + 1f;

        notification.CreateNotification("Carrot, +1 Weapon Speed", GetComponent<SpriteRenderer>().sprite);

        Destroy(gameObject);
    }

    void pickupMagnet(Collider2D collision)
    {
        shoot.homingWeapon = true;

        notification.CreateNotification("Magnet, Homing Weapon", GetComponent<SpriteRenderer>().sprite);

        Destroy(gameObject);
    }
}
