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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(("Ground")))
        {
            isGrounded = false;
        }
    }
}