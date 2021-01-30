using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyReset : MonoBehaviour
{
    public NavMeshAgent enemy;
    public static bool isResetting;
    public Transform waypoint;

    public void Awake()
    {
        enemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isResetting)
        {
            Resetting();
        }
    }

    public void Resetting()
    {
        enemy.SetDestination(waypoint.position);
        isResetting = false;
        EnemyRotation.isSearching = true;
    }
}
