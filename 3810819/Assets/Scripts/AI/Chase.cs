using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public float attackRange;
    //public float aiMoveSpeed;
    

    NavMeshAgent agent;
    Detection detection;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponent<Detection>();
    }

    void Update()
    {
        if(detection.target != null)
        {
            if(detection.rangeToTarget <= attackRange)
            {
                SendMessage("SetBehaviour", "Attack");
            }
            else
            {
                agent.SetDestination(detection.target.position);                
            }
        }
        else
        {
            SendMessage("SetBehaviour", "Investigate");
        }

    }
}
