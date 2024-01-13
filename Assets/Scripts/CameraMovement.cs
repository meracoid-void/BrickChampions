using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the camera movement
    public float rotationSpeed = 100.0f; // Speed of the camera rotation
    public float verticalSpeed = 5.0f; // Speed of the camera vertical movement

    void Update()
    {
        // Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

        // Horizontal and Forward/Backward Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

        // Vertical Movement (Up and Down)
        if (Input.GetKey(KeyCode.R)) // Replace R with KeyCode.Space if you prefer using Space for moving up
        {
            movementDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.F)) // Replace F with KeyCode.LeftControl if you prefer using Ctrl for moving down
        {
            movementDirection += Vector3.down;
        }

        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
