using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public static float speed = 10;
    private float waitTime;
    public float startWaitTime;

    public Transform[] patrolPoint;
    private int index;

    // Start is called before the first frame update
    void Start()
    {

        waitTime = startWaitTime;
        index = Random.Range(0, patrolPoint.Length);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[index].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolPoint[index].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                index = Random.Range(0, patrolPoint.Length);
                waitTime = startWaitTime;

            }
            else
            {

                waitTime -= Time.deltaTime;
            }
        }

    }

}