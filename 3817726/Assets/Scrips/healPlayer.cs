using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class healPlayer : MonoBehaviour
    {
        public int health = 25;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            playerStats PlayerStats = other.GetComponent<playerStats>();

            if (PlayerStats != null)
            {
                PlayerStats.TakeHealth(health);
                Debug.Log("Gain 25");
            }

        }
    }
}
