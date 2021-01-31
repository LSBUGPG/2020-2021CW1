using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    //So the player turns more smoothly in another direction
    public float turnsmoothTime = 0.05f;
    float turnsmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
        
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
