using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossController : MonoBehaviour
{
    public float speed = 3f; // Adjust speed according to your game
    public float avoidRadius = 1f; // Adjust the radius of the obstacle avoidance
    public float detectionRange = 5f; // Range at which the mini-boss detects the player
    public float attackRange = 2f; // Range at which the mini-boss can attack the player
    public float attackCooldown = 2f; // Cooldown between attacks
    public int damage = 10; // Damage dealt to the player

    private Transform player;
    private bool canAttack = true; // Variable to track whether the mini-boss can currently attack

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(transform.position, player.position) <= detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 avoidVector = AvoidObstacles();

            // Combine direction towards player with obstacle avoidance
            Vector3 movementDirection = (direction + avoidVector).normalized;

            // Move mini-boss
            transform.Translate(movementDirection * speed * Time.deltaTime);

            // Check if the player is within attack range and the mini-boss can attack
            if (Vector3.Distance(transform.position, player.position) <= attackRange && canAttack)
            {
                // Perform attack
                AttackPlayer();

                // Start cooldown timer
                StartCoroutine(AttackCooldown());
            }
        }
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

    void AttackPlayer()
    {
        // Deal damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        // Add additional attack logic here if needed
        Debug.Log("Attacking player!");
    }

    IEnumerator AttackCooldown()
    {
        // Set canAttack to false to prevent further attacks during cooldown
        canAttack = false;

        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(attackCooldown);

        // Set canAttack to true to allow the mini-boss to attack again
        canAttack = true;
    }
}

