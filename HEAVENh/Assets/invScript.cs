using System.Collections;
using System.Collections.Generic;
// InventoryUI.cs

using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour

{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotsParent;
    public Sprite[] itemSprites;
    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {

        // Clear existing slots
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate slots based on inventory size
        for (int i = 0; i < inventory.inventorySize; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            // Customize slot appearance or behavior as needed
        }

        // Update slot contents based on inventory items
        for (int i = 0; i < inventory.items.Count; i++)
        {
            Transform slot = slotsParent.GetChild(i);
            Image slotImage = slot.GetComponent<Image>();


            // Set slot image and text based on inventory item
            slotImage.sprite = itemSprites[inventory.items[i].id];



        }
        for (int i = 0; i < inventory.items.Count; i++)
        {
            Transform slot = slotsParent.GetChild(i);
            Image slotImage = slot.GetComponent<Image>();

            // Check if the item index is within the bounds of itemSprites
            if (inventory.items[i].id < itemSprites.Length)
            {
                slotImage.sprite = itemSprites[inventory.items[i].id];
            }
        }
    }
}
