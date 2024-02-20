using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Image[] itemFrames; // Array of Image components representing item slots

    // Add an item to the inventory
    public void AddItem(Sprite itemSprite)
    {
        // Find an empty slot in the inventory
        for (int i = 0; i < 6; i++)
        {
            if (itemFrames[i].sprite == null)
            {
                // Assign the item sprite to the empty slot
                itemFrames[i].sprite = itemSprite;
                return;
            }
        }

        // If there are no empty slots, the inventory is full
        Debug.LogWarning("Inventory is full. Cannot add item.");
    }

    // Remove an item from the inventory
    public void RemoveItem(Sprite itemSprite)
    {
        // Find the slot containing the item sprite and clear it
        for (int i = 0; i < 6; i++)
        {
            if (itemFrames[i].sprite == itemSprite)
            {
                itemFrames[i].sprite = null;
                return;
            }
        }

        // If the item is not found in any slot
        Debug.LogWarning("Item not found in inventory.");
    }
}