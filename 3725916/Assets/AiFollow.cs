using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollow : MonoBehaviour
{
    private NavMeshAgent Enemy;

    public Transform Player;

    public float EnemyDistanceRun = 4.0f;

    public Transform SpawnPoint;

    public GameObject Prefab;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        //Run Towards Player

        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            Enemy.SetDestination(newPos);
        }
    }

    void OnTriggerEnter ()
    {
        Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Item picked up");
            Destroy(gameObject);
        }
    }



}

