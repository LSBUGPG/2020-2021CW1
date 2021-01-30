using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private GameObject player;
    private Rigidbody rb;
    private float dir;
    //private Vector3 leftPos;
    //private Vector3 rightPos;

    //private bool leftPosHitObject;
    //private bool rightPosHitObject;
    // Start is called before the first frame update
    void Start()
    {
        //leftPosHitObject = false;
        //rightPosHitObject = false;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //dir = Vector3.Distance(player.transform.position, transform.position);
        transform.LookAt(player.transform.position);

        RaycastHit hit;
      

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if (hit.collider.CompareTag("Player"))
            {
                rb.AddForce(new Vector3(transform.forward.x * speed * Time.deltaTime, 0, transform.forward.z * speed * Time.deltaTime), ForceMode.Impulse);
            }
        }
        

    }
}
