using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip clicksound;

    public void Clicksound()
    {
        mySounds.PlayOneShot(clicksound);
    }
}
