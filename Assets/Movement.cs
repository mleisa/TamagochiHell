using System;
using Unity.VisualScripting;
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
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private float colliderExpansionSpeed = 1;

    private void Awake()
    {
        t = transform;
        _collider.radius = 0;
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

        if ((vertical != 0 || horizontal != 0) && _collider.radius <= 5)
        {
            _collider.radius += colliderExpansionSpeed * Time.fixedDeltaTime;
        }
        else
        {
            if (_collider.radius >= 0)
            {
                _collider.radius -= colliderExpansionSpeed * Time.fixedDeltaTime;
            }
        }
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