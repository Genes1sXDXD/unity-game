using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MaterialSpawner : MonoBehaviour
{
    public GameObject woodPrefab;
    public GameObject stonePrefab;
    public GameObject ironPrefab;

    public int numberOfMaterialsToSpawn = 10;  // Adjust the number as needed

    public UnityEvent OnMaterialSpawned;

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
            int materialType = Random.Range(0, 10);

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
                case 3:
                    materialPrefab = woodPrefab;
                    break;
                case 4:
                    materialPrefab = woodPrefab;
                    break;
                    case 5:
                        materialPrefab = stonePrefab;
                    break;
                case 6:
                    materialPrefab = woodPrefab;
                    break;
                    case 7:
                    materialPrefab = woodPrefab;
                        ; break;
                    case 8:
                        materialPrefab = woodPrefab;

                    break;
                    case 9:
                    materialPrefab = stonePrefab;
                    break;
                default:
                    materialPrefab = woodPrefab;  // Default to wood if something goes wrong
                    break;
            }
            // Invoke the event when materials are spawned
            if (OnMaterialSpawned != null)
            {
                OnMaterialSpawned.Invoke();
            }

            Instantiate(materialPrefab, worldSpawnPosition, Quaternion.identity);
          
            materialPrefab.transform.position = new Vector3(worldSpawnPosition.x, worldSpawnPosition.y, 0f);

        }
    }
}