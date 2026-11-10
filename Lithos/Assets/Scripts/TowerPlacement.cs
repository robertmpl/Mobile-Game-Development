using UnityEngine;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    private bool towerPanelOpen = true;

    [SerializeField] private GameObject towerPanel;

    public void ToggleTowerPanel()
    {
        if (towerPanelOpen)
        {
            towerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-125f, 0f);
        } else
        {
            towerPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(125f, 0f);
        }

        towerPanelOpen = !towerPanelOpen;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
