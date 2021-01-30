using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public AudioSource playSound;
    public void OnMouseDown()
    {
        playSound.Play();
    }


}
