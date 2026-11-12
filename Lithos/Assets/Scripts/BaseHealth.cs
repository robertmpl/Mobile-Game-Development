using UnityEngine;
using TMPro;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;

    public float baseHealth = 100f;

    public void DamageBase(float damage)
    {
        baseHealth = baseHealth - damage;

        healthText.text = "Health: " +baseHealth;

        if (baseHealth <= 0)
        {
            
        }
    }

    public void AddHealth(float healthGain)
    {
        baseHealth = baseHealth + healthGain;

        healthText.text = "Health: " +baseHealth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
