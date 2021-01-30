using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = false;
        backward = false;
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            forward = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (!Input.GetKey(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        if (!Input.GetKey(KeyCode.S))
        {
            backward = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            right = false;
        }

    }

    private void FixedUpdate()
    {
        if (!forward && !backward && !left && !right)
        {
            rb.drag = 6f;
        }
        if (forward)
        {
            rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.drag = 1f;
        }
        if (backward)
        {
            rb.AddForce(-transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.drag = 1f;
        }
        if (left)
        {
            transform.Rotate(0,-2f,0, Space.Self);
            rb.drag = 6f;
            if (forward || backward)
            {
                rb.drag = 1f;
                rb.AddForce(-transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
        if (right)
        {
            transform.Rotate(0, 2f, 0, Space.Self);
            rb.drag = 6f;
            if (forward || backward)
            {
                rb.drag = 1f;
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
    }
}
