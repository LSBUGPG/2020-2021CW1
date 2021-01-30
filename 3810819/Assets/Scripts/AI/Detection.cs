using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public float viewDistance;
    public float fov;
    Transform player;

    
    internal Transform target;
    internal float rangeToTarget;
    internal Vector3 lastKnownLocation;

    void Awake()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawFrustum(Vector3.zero, fov, viewDistance, 0.5f, 1.0f);
        Gizmos.DrawWireSphere(Vector3.zero, viewDistance);
    }
    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 toPlayer = player.transform.position - transform.position;
            float distance = toPlayer.magnitude;
            if(distance < viewDistance && Vector3.Angle(toPlayer, transform.forward) < 0.5f * fov)
            {
                rangeToTarget = distance;
                /*if(target == null)
                {
                    SendMessage("SetBehaviour", "Chase");
                }
                target = player.transform;*/
                PlayerVisibility();
            }
            else
            {
                if(target != null)
                {
                    lastKnownLocation = target.transform.position;                    
                }
                target = null;                
            }
        }
    }

    void PlayerVisibility()
    {
        Vector3 direction = player.transform.position - transform.position;
        RaycastHit hit;

        if(Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag.Equals(player.transform.tag))
            {
                if (target == null)
                {
                    SendMessage("SetBehaviour", "Chase");
                }
            }
        }        
        target = player.transform;
    }
}
