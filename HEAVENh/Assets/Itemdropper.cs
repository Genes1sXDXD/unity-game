using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public Item itemToDrop; // Assign the corresponding item in the Inspector

    private void OnDestroy()
    {
        DropItem();
    }

    private void DropItem()
    {
        // Instantiate the item in the scene
        Instantiate(itemToDrop.prefab, transform.position, Quaternion.identity);
    }
}
