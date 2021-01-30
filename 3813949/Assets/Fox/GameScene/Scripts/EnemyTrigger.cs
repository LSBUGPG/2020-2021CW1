using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject Enemy;
    public Transform spawnPoint;
    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && triggered == false)
        {
            Instantiate(Enemy,spawnPoint.position,Quaternion.identity);
            triggered = true;
        }
    }
}

