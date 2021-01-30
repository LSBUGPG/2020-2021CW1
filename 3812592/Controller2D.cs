using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public static Rigidbody2D rB;
    public float moveSpeed = 5.0f;
    float inputX;

    public LayerMask ground;
    public bool debug = false;

    public static bool isGrounded = false;

    public float jumpRem = 0;
    public float jumpRemTime = 0.2f;

    public float groundedRem = 0;
    public float groundedRemTime = 0.2f;

    public float jumpVel = 10;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        groundedRem -= Time.deltaTime;
        if (isGrounded == true)
        {
            groundedRem = groundedRemTime;
        }

        jumpRem -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRem = jumpRemTime;
        }

        if ((jumpRem > 0) && (groundedRem > 0))
        {
            jumpRem = 0;
            groundedRem = 0;
            rB.velocity = new Vector2(rB.velocity.x, jumpVel);
        }

        inputX = Input.GetAxisRaw("Horizontal");
        rB.velocity = new Vector2(inputX * moveSpeed, rB.velocity.y);
    }

    void FixedUpdate()
    {
        if (Physics2D.Raycast(transform.position, -Vector2.up, 1.05f, ground))
        {
            isGrounded = true;
        }
        else
            isGrounded = false;
        if (debug)
        {
            Debug.DrawRay(transform.position, -Vector2.up * 1.1f, Color.green);
        }
    }
}
