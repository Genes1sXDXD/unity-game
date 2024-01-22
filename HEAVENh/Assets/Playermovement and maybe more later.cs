using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private BoxCollider2D playAreaCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playAreaCollider = GameObject.Find("Grid").GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();

        // Move the character using physics
        rb.velocity = movement * speed;

        // Clamp the player's position within the play area
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, playAreaCollider.bounds.min.x, playAreaCollider.bounds.max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, playAreaCollider.bounds.min.y, playAreaCollider.bounds.max.y);
        transform.position = clampedPosition;
    }
}
