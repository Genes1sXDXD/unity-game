using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int inventorySize = 20;

    public bool AddItem(Item item)
    {
        if (items.Count < inventorySize)
        {
            items.Add(item);
            // Update UI or perform other actions
            return true;
        }
        else
        {
            // Inventory full, handle accordingly
            return false;
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        // Update UI or perform other actions
    }

    public bool HasItem(Item item)
    {
        return items.Contains(item);
    }
}
