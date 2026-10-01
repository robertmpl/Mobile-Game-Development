using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{
    public Sprite openChestSprite;

    [Header("Settings")]
    public GameObject heart;
    public GameObject[] drops; // List of prefabs that can be dropped by the chest
    public AudioClip openSound;

    GameObject player;
    PlayerShoot shoot;
    
    bool chestOpened = false;
    private void Start()
    {
        player = GameObject.Find("Knight");
        shoot = player.GetComponent<PlayerShoot>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!chestOpened) // If the chest hasnt been opened yet, prevents opening the same chest multiple times
        {
            if (shoot.homingWeapon) // Since homing weapon only has its effect once, replace it with a different item
            {
                drops[3] = heart;
            }

            if (collision.gameObject.CompareTag("Player")) // If the player is the involved in the collision
            {
                chestOpened = true;

                AudioSource.PlayClipAtPoint(openSound, transform.position);

                gameObject.GetComponent<SpriteRenderer>().sprite = openChestSprite; // Change to opened chest sprite for visual feedback

                GrantItem(); // Grant a random item
            }
        }
    }
    private IEnumerator EnableCollider(GameObject item, float delay)
    {
        yield return new WaitForSeconds(delay); // Yields the code for the specified delay

        item.GetComponent<BoxCollider2D>().transform.localScale = new Vector3(1f, 1f, 1f); // Change size back to default
        item.GetComponent<BoxCollider2D>().enabled = true; // Re-enable collider so the item can be picked up

        Destroy(gameObject); // Destroy the chest
    }

    private void GrantItem()
    {
        GameObject newItem = Instantiate(drops[Random.Range(0,drops.Length)]); // Generate a random item from the drops list

        newItem.GetComponent<BoxCollider2D>().enabled = false; // Remove collision to prevent instant collection

        newItem.transform.localScale = new Vector3(0.7f,0.7f,0.7f); // Visual feedback for the period of time that the item is not collidable

        newItem.transform.position = gameObject.transform.position; // Item spawns at the position of the chest

        newItem.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * 3; // Send the item in the direction of the chest opening for visual feedback

        StartCoroutine(EnableCollider(newItem, 1f)); // Run the function without interrupting the code
    }
}
