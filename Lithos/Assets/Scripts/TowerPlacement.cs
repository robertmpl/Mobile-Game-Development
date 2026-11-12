using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Button button;

    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private GameObject towerPreviewPrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private IOSHaptics IosHaptics;

    private GameObject towerPreview;
    private Vector2 pointerPosition;
    private bool isDragging = false;

    void Awake()
    {
        IosHaptics = IosHaptics.GetComponent<IOSHaptics>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        pointerPosition = eventData.position;

        towerPreview = Instantiate(towerPreviewPrefab);
        
        IosHaptics.Light();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        pointerPosition = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, 10f));

        worldPosition.z = 0f;

        GameObject placedTower = Instantiate(towerPrefab, worldPosition, Quaternion.identity);

        IosHaptics.Medium();

        Destroy(towerPreview);
        towerPreview = null;
    }

    void Update()
    {
        if (!isDragging || towerPreview == null)
        {
            return;
        }

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(pointerPosition.x, pointerPosition.y, 10f));

        worldPosition.z = 0f;

        towerPreview.transform.position = worldPosition;
    }
}
