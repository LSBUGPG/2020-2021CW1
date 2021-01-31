using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class damagePlayer : MonoBehaviour
    {
        public int damage = 25;

        // Start is called before the first frame update
        private void OnTriggerEnter(Collider other)
        {
            playerStats PlayerStats = other.GetComponent<playerStats>();

            if (PlayerStats != null)
            {
                PlayerStats.TakeDamage(damage);
                Debug.Log("Lose 25");

            }

        }
    }
}
