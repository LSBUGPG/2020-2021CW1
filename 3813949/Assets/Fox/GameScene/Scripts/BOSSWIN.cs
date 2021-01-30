using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSSWIN : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("Level6");
    }
}
