using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public CanvasScaler canvasScaler;

    void Start()
    {
        // Set the UI scale mode to Scale with Screen Size
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        // Set the reference resolution to 1920x1080 pixels
        canvasScaler.referenceResolution = new Vector2(1920, 1080);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}