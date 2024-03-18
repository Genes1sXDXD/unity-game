using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script should be attached to a player or a character that can pick up items.
public class PickupObject : MonoBehaviour
{
    public int amountOfObjectsPickedUp; // Track the number of objects picked up.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUpItem"))
        {
            // Ensure the item has the 'Item' script attached and it is tagged correctly in the editor.
            Item itemScript = other.GetComponent<Item>();
            if (itemScript != null)
            {
                // Use the item's ID or functionality as needed. Example: add to inventory, etc.
                int itemID = itemScript.objectID;

                // Increment the counter for the picked-up objects.
                amountOfObjectsPickedUp++;

                // Optional: Destroy the item game object after picking it up.
                Destroy(other.gameObject);

                // Log the pickup event.
                Debug.Log("Item picked up. Total items: " + amountOfObjectsPickedUp);
            }
            else
            {
                // If the 'Item' script is missing, log a warning.
                Debug.LogWarning("PickUpItem tag found, but Item script is missing!");
            }
        }
    }
}
