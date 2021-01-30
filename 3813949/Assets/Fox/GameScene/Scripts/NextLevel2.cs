using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
   public void ButtonStart()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
