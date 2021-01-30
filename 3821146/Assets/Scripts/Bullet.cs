using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }   
    }
}
