using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        // Implement your enemy's movement logic here
        Move();
    }

    void Move()
    {
        // Example: Move the enemy to the right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    // You can add more enemy behavior, detection, and attack logic as needed
}

