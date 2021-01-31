using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    //Moves A.I to waypoints set
    public Transform[] waypoints;
    public int speed;

    //Sets up Waypoints as a list and judges distance
    private int waypointIndex;
    private float dist;


    // Start is called before the first frame update
    void Start()
    {
        //Two points the ememy will walk too
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(dist < 1f)
            {
                IncreaseIndex();
            }
        Patrol();
        
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void OnEnable()
    {
        IncreaseIndex();
    }
}
