using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    
   public void ButtonStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }


}
                