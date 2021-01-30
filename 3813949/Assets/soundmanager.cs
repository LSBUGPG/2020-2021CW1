using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public static AudioClip playerHitSound, FireSound, jumpSound, enemyDeathSound;
    static AudioSource audiosrc;
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("PlayerHit");
        FireSound = Resources.Load<AudioClip>("fire");
        jumpSound = Resources.Load<AudioClip>("jump");
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

        audiosrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "fire":
                audiosrc.PlayOneShot(FireSound);
                break;

            case "PlayerHit":
                audiosrc.PlayOneShot(playerHitSound);
                break;

            case "jump":
                audiosrc.PlayOneShot(jumpSound);
                break;

            case "enemyDeathSound":
                audiosrc.PlayOneShot(enemyDeathSound);
                break;
        }
    }
                
}
