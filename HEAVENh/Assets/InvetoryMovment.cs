using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// PlayerController.cs

public class PlayerInventoryController : MonoBehaviour
{
    public Inventory inventory;
    public KeyCode inventoryKey = KeyCode.I;

    private void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            // Toggle inventory visibility
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        // Implement logic to show/hide the inventory UI
    }
}

