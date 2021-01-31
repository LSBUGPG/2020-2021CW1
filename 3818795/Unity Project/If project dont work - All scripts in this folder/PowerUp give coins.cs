using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpgivecoins : MonoBehaviour
{

    public static int Score3;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            Score3 += 250;
            Debug.Log("Test");
            Destroy(other.gameObject);

        }
    }


}

