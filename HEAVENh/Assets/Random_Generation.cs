using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSpawner : MonoBehaviour
{
    public GameObject woodPrefab;
    public GameObject stonePrefab;
    public GameObject ironPrefab;

    public int numberOfMaterialsToSpawn = 10;  // Adjust the number as needed

    void Start()
    {
        SpawnMaterials();
    }

    void SpawnMaterials()
    {
        for (int i = 0; i < numberOfMaterialsToSpawn; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height));

            // Convert screen position to world position
            Vector3 worldSpawnPosition = Camera.main.ScreenToWorldPoint(spawnPosition);

            // Choose a random material type
            int materialType = Random.Range(0, 3);

            GameObject materialPrefab;

            // Instantiate the chosen material
            switch (materialType)
            {
                case 0:
                    materialPrefab = woodPrefab;
                    break;
                case 1:
                    materialPrefab = stonePrefab;
                    break;
                case 2:
                    materialPrefab = ironPrefab;
                    break;
                default:
                    materialPrefab = woodPrefab;  // Default to wood if something goes wrong
                    break;
            }

            Instantiate(materialPrefab, worldSpawnPosition, Quaternion.identity);
        }
    }
}