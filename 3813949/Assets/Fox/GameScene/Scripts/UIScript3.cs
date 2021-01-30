using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIScript8 : MonoBehaviour
{
    // Start is called before the first frame update
   public void ButtonStart()
    {
        SceneManager.LoadScene("Level5");
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
