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

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        rb.velocity = movement * (speed * Time.deltaTime);
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
    }

}
