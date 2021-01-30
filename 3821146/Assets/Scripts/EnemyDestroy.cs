using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public Rigidbody rb;

    void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.tag == "Bullet")
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

  
    private void DestroyEnemy()
    {
        Destroy(rb);
      
    }

}
