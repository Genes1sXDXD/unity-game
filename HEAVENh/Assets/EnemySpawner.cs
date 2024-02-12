using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public float spawnRadius = 5f; // Distance from camera bounds to spawn enemies
    public float spawnInterval = 1f; // Time interval between enemy spawns
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    private float timer;

    void Start()
    {
        mainCamera = Camera.main;
        CalculateBounds();
        timer = spawnInterval; // Start the timer to spawn immediately
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnInterval; // Reset the timer
        }
    }

    void SpawnEnemy()
    {
        // Calculate a random position outside of the camera bounds but close by
        Vector3 spawnPosition = GetRandomSpawnPosition();

        // Spawn the enemy at the calculated position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Calculate a random angle and distance from the camera center
        float angle = Random.Range(0f, 2f * Mathf.PI);
        float distance = Random.Range(spawnRadius, 2 * spawnRadius); // Ensure enemy spawns outside the spawn radius

        // Calculate the spawn position
        Vector3 cameraCenter = mainCamera.transform.position;
        Vector3 spawnPosition = cameraCenter + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * distance;

        return spawnPosition;
    }


    void CalculateBounds()
    {
        if (mainCamera == null)
            return;

        // Calculate camera bounds
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }
}
