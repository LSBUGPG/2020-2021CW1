using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase_Player : MonoBehaviour
{
    public Patrolling patrolling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Vector3 position = collider.transform.position;
            position.y = transform.position.y;
            transform.LookAt(position);
            transform.position += transform.forward * 3f * Time.deltaTime;
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            patrolling.enabled = false;
            
        }
    }



    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            patrolling.enabled = true;
        }
    }
}
