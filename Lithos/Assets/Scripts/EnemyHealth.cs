using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    
    private GameObject waveManager;
    
    void Awake()
    {
        waveManager = GameObject.Find("WaveManager");
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            waveManager.GetComponent<WaveManager>().EnemyDestroyed();
            Destroy(gameObject);
        }
    }
}
