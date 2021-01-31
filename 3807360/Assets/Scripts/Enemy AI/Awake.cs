using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask IsPlayer;
    public float sightRange, attackRange;
    public bool InSightRange, InAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        InSightRange = Physics.CheckSphere(transform.position, sightRange, IsPlayer);
        InAttackRange = Physics.CheckSphere(transform.position, attackRange, IsPlayer);

        if (!InSightRange && !InAttackRange) Patroling();
        if (InSightRange && !InAttackRange) ChasePlayer();
        if (InAttackRange && InSightRange) AttackPlayer();
    }
}
