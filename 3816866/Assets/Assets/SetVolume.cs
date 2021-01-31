using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer Mixer;

    public void setlevel (float sliderValue)
    {
        Mixer.SetFloat("MusicVol", Mathf.Log10 (sliderValue) *20);
    }
}
