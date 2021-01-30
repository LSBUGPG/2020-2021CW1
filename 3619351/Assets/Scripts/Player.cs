using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start ()
    {   
    body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}

// https://www.youtube.com/watch?v=GjTTqz39kLY This link will provide more information about the scripts if confused.
 // direction = Vector2.up; ((This Code automatically moves upwards)).