using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f; // Public variable for speed

    private Rigidbody2D RB; // Private variable for Rigidbody2D
    private Vector2 input; // Private variable for input
    private Animator anim; // Private variable for Animator
    private Vector2 lastMoveDirection; // Private variable for last move direction
    private bool facingLeft = true; // Private variable for facing left direction

    void Start()
    {
        // Get Rigidbody2D component
        RB = GetComponent<Rigidbody2D>();
        // Get Animator component
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInputs();
        Animate();
        Flip();
    }

    void FixedUpdate()
    {
        // Calculate movement based on input and speed
        RB.velocity = input * speed;
    }

    void ProcessInputs()
    {
        // Get raw input axes
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Reset move direction
        input = Vector2.zero;

        // Check if there's movement
        if (moveX != 0 || moveY != 0)
        {
            // Set input vector
            input.x = moveX;
            input.y = moveY;
            // Update last move direction
            lastMoveDirection = input;
        }
    }

    void Animate()
    {
        // Set animator parameters
        anim.SetFloat("moveX", input.x);
        anim.SetFloat("moveY", input.y);
        anim.SetFloat("moveMagnitude", input.magnitude);
        anim.SetFloat("lastMoveX", lastMoveDirection.x);
        anim.SetFloat("lastMoveY", lastMoveDirection.y);
    }

    void Flip()
    {
       
    }
}