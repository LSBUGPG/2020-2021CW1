using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 10f;
    public float JumpSpeed = 5f;
    private Rigidbody rb;
    private bool grounded;
    public GameObject groundcheck;
    public LayerMask ground;

  
    

    void Start ()    
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        
        
    }

    void Update ()
    {   
       

        float inputZ = Input.GetAxis ("Vertical");
        float inputX = Input.GetAxis ("Horizontal");
        Vector3 movement = new Vector3(inputX,0,inputZ);
        Vector3 normalMovement = Vector3.Normalize(movement);
        Vector3 forwardMovement = (transform.forward * inputZ * speed).normalized;
        Vector3 sidewaysMovement = (transform.right * inputX * speed).normalized;
        Vector3 normalizedMoved = (forwardMovement + sidewaysMovement).normalized;
        rb.velocity = new Vector3(normalizedMoved.x * speed,rb.velocity.y,normalizedMoved.z*speed);
        
        if (Input.GetKeyDown ("escape")) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        grounded = Physics.Raycast(groundcheck.transform.position, Vector2.down, 0.1f, ground);

        if (Input.GetAxis("Jump") != 0 && grounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpSpeed, rb.velocity.z);
            
        }
    }
}