using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public int health = 10;
    public Transform modelTransform;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {


        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (moveX != 0 || moveZ != 0)
        {
            modelTransform.rotation = Quaternion.LookRotation(new Vector3(moveX, 0f, moveZ));

        }


        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        GetComponent<Rigidbody>().velocity = movement * moveSpeed * Time.deltaTime;

    }
     void onTriggerEnter (Collider other)
     {
        if (other.gameObject.CompareTag("Trap"))
        {
            Destroy (gameObject);
        }

     }



    
}
