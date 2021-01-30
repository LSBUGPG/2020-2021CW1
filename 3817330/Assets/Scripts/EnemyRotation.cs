using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public float rotationSpeed;
    [SerializeField] public static bool isSearching = true;
    public EnemyChase startChase;
    //public GameObject player;

    public void Update()
    {
        if (isSearching)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
            RayCasting();
        }
        else
        {
            EnemyChase.isChasing = true;
        }
    }

    public void RayCasting()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        float maxDirection = 10f;

        Ray ray = new Ray(origin, direction);

        bool result = Physics.Raycast(ray, out RaycastHit raycastHit, maxDirection);

        /*if (raycastHit.collider != null)
        {
            Debug.DrawRay(origin,  raycastHit.point, Color.red);
            if (raycastHit.collider.CompareTag("Player"))
            {
                isSearching = false;
                //EnemyChase.isChasing = true;
                print("FOUND YOU");
            }
        }
        else
        {
            Debug.DrawRay(origin, direction * maxDirection, Color.green);
        }*/

        //^I DUN GOOFED :D

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.DrawRay(origin, raycastHit.point, Color.red);
            if (hit.collider.CompareTag("Player"))
            {
                isSearching = false;
                EnemyChase.isChasing = true;
                print("FOUND YOU");
            }
        }
        else
        {
            Debug.DrawRay(origin, direction * maxDirection, Color.green);
        }
    }
}
