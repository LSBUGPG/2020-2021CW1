using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Investigate : MonoBehaviour
{

    NavMeshAgent agent;
    Detection detection;

    public GameObject player;
    public GameObject playerGhost;
    public float distance;

   

    // Start is called before the first frame update
    void Awake()
    {
        detection = GetComponent<Detection>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        agent.SetDestination(detection.lastKnownLocation);

        SpawnPlayerGhost();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.hasPath || agent.remainingDistance < distance)
        {
            SendMessage("SetBehaviour", "Patrol");
        }
    }

    public void SpawnPlayerGhost()
    {
        playerGhost.transform.position = player.transform.position;
        playerGhost.SetActive(true);
    }

    private void OnDisable()
    {
        playerGhost.SetActive(false);
    }
}
