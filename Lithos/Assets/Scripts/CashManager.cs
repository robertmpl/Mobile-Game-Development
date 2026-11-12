using UnityEngine;
using TMPro;

public class CashManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cashText;

    public float cash = 100f;

    public bool transaction(float price)
    {
        if (cash >= price)
        {
            cash = cash - price;
            cashText.text = "$" +cash;
            return true;
        }

        return false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cashText.text = "$" +cash;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
