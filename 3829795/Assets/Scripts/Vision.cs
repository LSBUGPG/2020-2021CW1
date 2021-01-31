using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public GameObject vision;
    public GameObject player;
    float maxFOVAngle = 45;
    float lookRadius = 8f;
    public bool canSeePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FovRadius = vision.gameObject.transform.forward * lookRadius;
        float distanceToPlayer = Vector3.Distance(player.gameObject.transform.position, vision.gameObject.transform.position);
        float playerAngle = Vector3.Angle(player.gameObject.transform.position - vision.gameObject.transform.position, FovRadius);

        if(playerAngle < maxFOVAngle && distanceToPlayer < lookRadius)
        {
            Debug.DrawRay(vision.transform.position, player.transform.position - vision.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(vision.transform.position, player.transform.position - vision.transform.position, out hit))
            {

                if(hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Hitting Player");
                    canSeePlayer = true;
                }
                
            }
            
        }
        else
        {
            canSeePlayer = false;
        }
    }
}