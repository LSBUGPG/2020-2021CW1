using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashSequence : MonoBehaviour
{



    public static int SceneNumber;
    void Start()
    {
        if (SceneNumber  == 4)
        {
            StartCoroutine(ToSplash1());
        }
    }

    
    IEnumerator ToSplash1 ()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }

}
