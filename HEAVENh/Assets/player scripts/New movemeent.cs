using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Adjust the speed as needed
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // Make sure to set the player tag in the Unity Editor for your player GameObject
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize(); // Ensure the vector is normalized to have a magnitude of 1

        transform.Translate(direction * speed * Time.deltaTime);
        // Move the enemy towards the player with the specified speed
    }
}
