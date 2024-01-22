using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hastighet för spelarens rörelse

    void Update()
    {
        // Hämta raw input från tangentbordet
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Beräkna rörelsevektorn
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        // Applicera rörelsen på spelaren
        transform.Translate(movement);
    }
}
