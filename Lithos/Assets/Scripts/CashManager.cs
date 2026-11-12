using UnityEngine;
using TMPro;

public class CashManager : MonoBehaviour
{
    [SerializeField] private TMP_Text cashText;

    public float cash = 100f;

    public bool Transaction(float price)
    {
        if (cash >= price)
        {
            cash = cash - price;
            cashText.text = "$" +cash;
            return true;
        }

        return false;
    }

    public void AddCash(float addedCash)
    {
        cash = cash + addedCash;
        cashText.text = "$" +cash;
    }

    public void RemoveCash(float removeCash)
    {
        cash = cash - removeCash;
        cashText.text = "$" +cash;
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
