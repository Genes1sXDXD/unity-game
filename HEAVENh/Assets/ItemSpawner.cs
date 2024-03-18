using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab you want to spawn
    public Transform parentTransform; // The parent object's transform

    public void Update()
    {
        GameObject Player = GameObject.Find("Player");
        PickupObject scriptAComponent = Player.GetComponent<PickupObject>();

        if (scriptAComponent.amountOfObjectsToSpawn > 0)
        {
            SpawnClone();
            scriptAComponent.amountOfObjectsToSpawn--;
        }
    }

    public void SpawnClone()
    {
        // Instantiate the prefab and set its parent to the specified parent transform
        GameObject clone = Instantiate(prefabToSpawn, parentTransform);
    }
}
