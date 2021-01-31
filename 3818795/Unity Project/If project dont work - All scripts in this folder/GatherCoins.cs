using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatherCoins : MonoBehaviour
{

    public static int Score;
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            Score += 50;
            Debug.Log("Test");
            Destroy(other.gameObject);

        }
    }

    
}
