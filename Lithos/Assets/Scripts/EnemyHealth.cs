using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    
    private GameObject waveManager;
    private GameObject cashManager;
    
    void Awake()
    {
        cashManager = GameObject.Find("Base");
        waveManager = GameObject.Find("WaveManager");
    }

    public void TakeDamage(float damage)
    {
        health = health - damage;
        cashManager.GetComponent<CashManager>().AddCash(1f);

        if (health <= 0)
        {
            waveManager.GetComponent<WaveManager>().EnemyDestroyed();
            Destroy(gameObject);
        }
    }
}
