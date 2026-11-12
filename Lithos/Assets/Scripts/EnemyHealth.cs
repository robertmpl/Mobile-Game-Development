using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    
    public void TakeDamage(float damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
