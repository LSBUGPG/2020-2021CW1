using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel2 : MonoBehaviour
{
    // Start is called before the first frame update
   public void ButtonStart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonCredits()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("Level2");
    }


}
