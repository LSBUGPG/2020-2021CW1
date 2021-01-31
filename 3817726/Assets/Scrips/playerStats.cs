using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class playerStats : MonoBehaviour
    {

        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public healthBar HealthBar;

        
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            HealthBar.SetMaxHealth(maxHealth);

        }
        
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            HealthBar.SetCurrentHealth(currentHealth);

        }

        public void TakeHealth(int health)
        {
            currentHealth = currentHealth + health;

            HealthBar.SetCurrentHealth(currentHealth);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "spike")
                Destroy(gameObject);
        }


    }
}

