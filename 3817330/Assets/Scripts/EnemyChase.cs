using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyChase : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform target;
    public static bool isChasing;

    public void Awake()
    {
        enemy.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isChasing)
        {
            enemy.SetDestination(target.position);
            Chasing();
        }
    }

    public void Chasing()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        float maxDirection = 10f;

        Ray ray = new Ray(origin, direction);

        bool result = Physics.Raycast(ray, out RaycastHit raycastHit, maxDirection);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (!hit.collider.CompareTag("Player"))
            {
                isChasing = false;
                EnemyReset.isResetting = true;
                /*Debug.DrawRay(origin, raycastHit.point, Color.red);
                isSearching = false;
                EnemyChase.isChasing = true;
                print("FOUND YOU");*/
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
