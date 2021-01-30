using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("main menu");
    }
}
