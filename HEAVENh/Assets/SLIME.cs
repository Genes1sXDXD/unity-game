using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    // Change direction interval in seconds
    public float changeDirectionInterval = 2f;
    private float timeSinceLastDirectionChange = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ensure the enemy has a collider for collision detection
        if (!GetComponent<Collider2D>())
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        // Start the enemy moving in a random direction
        SetRandomDirection();
    }

    void Update()
    {
        Move();

        // Check if it's time to change direction
        timeSinceLastDirectionChange += Time.deltaTime;
        if (timeSinceLastDirectionChange >= changeDirectionInterval)
        {
            SetRandomDirection();
            timeSinceLastDirectionChange = 0f; // Reset the timer
        }
    }

    void Move()
    {
        // Move the enemy using Rigidbody2D
        rb.velocity = transform.right * moveSpeed;
    }

    void SetRandomDirection()
    {
        // Choose a random angle between 0 and 360 degrees
        float randomAngle = Random.Range(0f, 360f);

        // Convert the angle to a direction vector
        Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Set the velocity based on the random direction
        rb.velocity = randomDirection * moveSpeed;
    }
}

