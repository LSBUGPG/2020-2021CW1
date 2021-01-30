using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackRange;
    Detection detection;

    void Awake()
    {
        detection = GetComponent<Detection>(); 
    }

    void Update()
    {
        if(detection.target == null)
        {
            SendMessage("SetBehaviour", "Investigate");
        }
        else if(detection.rangeToTarget > attackRange)
        {
            SendMessage("SetBehaviour", "Chase");
        }
        else
        {
            Debug.Log("Attack");
        }
    }

    public void PlayerDamage()
    {

    }
}
