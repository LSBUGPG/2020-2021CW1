using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent02 : MonoBehaviour
{
    public Transform target1;
    NavMeshAgent agent;
    Transform theTarget;
    public GameObject[] targets;
    int index = 0;
    Vision vision;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        vision = GetComponent<Vision>();
        agent = GetComponent<NavMeshAgent>();
        targets = GameObject.FindGameObjectsWithTag("target");
        
        theTarget = targets[index].transform;
        theTarget.GetComponent<Target>().TurnOnCollider();  
    }
    

    void TurnOffTargetColliders()
    {
        foreach (var target in targets)
        {
            target.GetComponent<Target>().TurnOffCollider();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (vision.canSeePlayer == true)
        {
            theTarget = player.transform;
        }
        else
        {
            theTarget = targets[index].transform;
        }
        agent.SetDestination(theTarget.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            SetNewTarget();
            ResetPreviousTarget();
        }
    }

    void SetNewTarget()
    {
        index += 1;
        if (index == targets.Length)
        {
            index = 0;
        }
        theTarget = targets[index].transform;
        theTarget.GetComponent<Target>().TurnOnCollider();
    }

    void ResetPreviousTarget()
    {
        if (index == 0)
        {
            targets[targets.Length - 1].transform.GetComponent<Target>().TurnOffCollider();
        }
        else
        {
            targets[index - 1].transform.GetComponent<Target>().TurnOffCollider();
        }
    }
}
