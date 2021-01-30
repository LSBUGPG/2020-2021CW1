using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverScript : MonoBehaviour
{
    public GameObject gameoverUI;

    void Update()
    {
        if (timerSystemScript.timeRemaining == 0)
        {
            gameover();
        }
    }

    public void retry()
    {
        Time.timeScale = 1f;
        timerSystemScript.timeRemaining = 1;
        SceneManager.LoadScene("TestLevel");
    }

    public void gameover()
    {
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
        pauseMenu.gameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        timerSystemScript.timeRemaining = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
