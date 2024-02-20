using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the inventory panel

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the E key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the visibility of the inventory panel
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
