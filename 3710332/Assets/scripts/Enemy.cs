using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField]float stoppingDistance;

    NavMeshAgent agent;

    GameObject target;
    // Get the enemy to search for the player within the level
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    //Get the enemy to stop within a certain distance of the player
    private void Update()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < stoppingDistance)
        {
            StopEnemy();
        }
        else
        {
            GoToTarget();
        }
        
    }

    // Stop the enemy when near the player
    private void GoToTarget()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }
    private void StopEnemy()
    {
        agent.isStopped = true;
    }
}
