using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent02 : MonoBehaviour
{
    public Transform target1;
    public Transform pickUpPoint;
    NavMeshAgent agent;
    Vector3 theTarget;
    public GameObject[] targets;
    int index = 0;
    bool dropBox = false;
    Box box;
    public Transform lineEnd;
    public LayerMask boxLayer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //targets = GameObject.FindGameObjectsWithTag("target");
        
        theTarget = targets[index].transform.position;
        targets[index].GetComponent<Target>().TurnOnCollider();  
    }
    

    void TurnOffTargetColliders()
    {
        foreach (var target in targets)
        {
            target.GetComponent<Target>().TurnOffCollider();
        }
    }

    void Update()
    {
        agent.SetDestination(theTarget);

        if (dropBox == true)
        {
            print("dropBox");
            float distance = Vector3.Distance(box.OriginalPosition(), transform.position);
            if (distance < 3.0f)
            {
                box.transform.parent = null;
                theTarget = targets[index].transform.position;
                box.ResetPosition();
            }
        }

        RaycastHit hit;

        if (Physics.Linecast(transform.position, lineEnd.position, out hit, boxLayer))
        {
            //hit.collider.gameObject.SetActive(false);
            box = hit.collider.gameObject.GetComponent<Box>();
            if (box.HaveYouMoved())
            {
                box.transform.parent = this.transform;
                box.transform.position = pickUpPoint.position;
                theTarget = box.OriginalPosition();
                dropBox = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("target"))
        {
            SetNewTarget();
            ResetPreviousTarget();
        }

        /* (other.CompareTag("box"))
        {
            box = other.gameObject.GetComponent<Box>();

            if (box.HaveYouMoved() == true)
            {
                print("Moved");
                box.transform.parent = this.transform;
                box.transform.position = pickUpPoint.position;
                theTarget.position = box.OriginalPosition();
                dropBox = true;
            }

        }*/
    }

    void SetNewTarget()
    {
        index += 1;
        if (index == targets.Length)
        {
            index = 0;
        }
        theTarget = targets[index].transform.position;
        targets[index].GetComponent<Target>().TurnOnCollider();
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
