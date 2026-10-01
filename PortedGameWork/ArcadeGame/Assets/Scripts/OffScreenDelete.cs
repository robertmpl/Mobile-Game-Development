using UnityEngine;

public class OffScreenDelete : MonoBehaviour
{
    // This script is used to remove things that go off the map such as projectiles to avoid lag.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) // If the collision exists
        {
            Destroy(collision.gameObject); // Destroy the object colliding
        }
    }
}
