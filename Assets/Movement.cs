using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public float maxRotation = 360;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));

        // rb.position += verticalInput * transform.forward * Time.deltaTime * speed;
        // rb.position += horizontalInput* transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        Debug.Log(gameObject.name);
    }
}