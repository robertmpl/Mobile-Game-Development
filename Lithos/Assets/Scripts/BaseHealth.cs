using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private GameObject gameOverPanel;

    public float baseHealth = 100f;

    public void DamageBase(float damage)
    {
        baseHealth = baseHealth - damage;

        healthText.text = "Health: " +baseHealth;

        if (baseHealth <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void AddHealth(float healthGain)
    {
        baseHealth = baseHealth + healthGain;

        healthText.text = "Health: " +baseHealth;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
