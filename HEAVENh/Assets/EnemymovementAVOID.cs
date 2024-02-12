using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlle : MonoBehaviour
{
    public float speed = 3f; // Adjust speed according to your game
    public float avoidRadius = 1f; // Adjust the radius of the obstacle avoidance

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 avoidVector = AvoidObstacles();

        // Combine direction towards player with obstacle avoidance
        Vector3 movementDirection = (direction + avoidVector).normalized;

        // Move enemy
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    Vector3 AvoidObstacles()
    {
        Vector3 avoidVector = Vector3.zero;
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, avoidRadius);

        foreach (Collider2D obstacle in obstacles)
        {
            if (obstacle.CompareTag("Obstacle"))
            {
                Vector3 obstacleDirection = (transform.position - obstacle.transform.position).normalized;
                avoidVector += obstacleDirection;
            }
        }

        return avoidVector;
    }
}
