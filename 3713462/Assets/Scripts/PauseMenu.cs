using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        //If playable or animated background on the menu screen use line of code below to un-pause when player returns to menu
        //Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Come back soon!");
        Application.Quit();
    }

}
