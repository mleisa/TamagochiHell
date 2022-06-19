using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float maxRotation = 360;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // if (movement == Vector3.zero)
        // {
        //     return;
        // }
        //
        // Quaternion targetRotation = Quaternion.LookRotation(movement);
        // targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxRotation * Time.fixedDeltaTime);
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        // rb.MoveRotation(targetRotation);
    }

}
