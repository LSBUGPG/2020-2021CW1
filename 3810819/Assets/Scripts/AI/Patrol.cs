using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] navPoint;
    NavMeshAgent agent;
    //public int destPoint;
    

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        Transform path = navPoint[Random.Range(0, navPoint.Length)];
        agent.SetDestination(path.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //GoToNextPoint();

        if (!agent.hasPath)
        {
            enabled = false;
            SendMessage("SetBehaviour", "Patrol");
        }
    }

    /*public void GoToNextPoint()
    {
        if (navPoint.Length == 0)
        {
            //return was here
            agent.destination = navPoint[destPoint].position;
            destPoint = (destPoint + 1) % navPoint.Length;
            
            return;
        }
    }*/
}
