using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody body;
    public float speed;
    public float jumpForce;
    private float vertical;
    private float horizontal;
    private bool isGrounded;
    Transform t;

    private void Awake()
    {
        t = transform;
    }

    void Start()
    {
        // Obtain the reference to our Rigidbody.
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Jump") > 0 && isGrounded)
        {
            body.AddForce(t.up * jumpForce);
        }

        Vector3 velocity = ((Vector3.forward * vertical) + (Vector3.right * horizontal)) * Time.fixedDeltaTime;
        velocity = velocity.normalized * speed;
        velocity.y = body.velocity.y;
        body.velocity = velocity;
    }

    // This function is a callback for when an object with a collider collides with this objects collider.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isGrounded = true;
        }
    }
    // This function is a callback for when the collider is no longer in contact with a previously collided object.
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isGrounded = false;
        }
    }
}