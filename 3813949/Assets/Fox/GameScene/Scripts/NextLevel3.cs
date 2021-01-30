using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
   public void ButtonStart()
    {
        SceneManager.LoadScene("Level4");
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
