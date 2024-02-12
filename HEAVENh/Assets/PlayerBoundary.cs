using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;
    public float padding = 0.1f; // Padding to keep player inside the camera bounds

    void Start()
    {
        mainCamera = Camera.main;
        CalculateBounds();
    }

    void Update()
    {
        // Keep the player inside the camera bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }

    void CalculateBounds()
    {
        if (mainCamera == null)
            return;

        // Calculate camera bounds
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        minX = bottomLeft.x + padding;
        maxX = topRight.x - padding;
        minY = bottomLeft.y + padding;
        maxY = topRight.y - padding;
    }
}
