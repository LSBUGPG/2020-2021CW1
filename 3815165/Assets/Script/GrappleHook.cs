using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private PlayerController movementScript;
    public float grappleDistance;
    public float grappleSpeed = 6.8f;

    void Start()
    {
        movementScript = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody> ();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine("Grapple1");
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            rb.useGravity = true;
            movementScript.enabled = true;
        }
    }

    IEnumerator Grapple1()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, grappleDistance);
        if (hit.transform)
        {
            rb.useGravity = false;
            Vector3 target = hit.transform.position;
            movementScript.enabled = false;
            rb.velocity = (target - transform.position) * grappleSpeed;
        }
        else
        {
            rb.useGravity = true;
        }
        yield return null;
    }
}
