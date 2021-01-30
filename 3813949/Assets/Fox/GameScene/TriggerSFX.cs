using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    public AudioSource playSound;

     void OnMouseDown()
    {
        playSound.Play();
    }
}
