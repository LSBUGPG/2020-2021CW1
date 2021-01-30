using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static float health;

    void Start()
    {
        health = 3;
    }

    void OnCollisionEnter2D(Collision2D colObj)
    {
        if (colObj.gameObject.tag == ("healthPickup"))
        {
            health += 1;
            Destroy(colObj.gameObject);
        }

        if (colObj.gameObject.tag == ("enemy"))
        {
            health -= 1;
            Destroy(colObj.gameObject);
        }
    }

    void Update()
    {
        Debug.Log(health);
    }
}
