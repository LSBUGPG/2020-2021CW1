using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    public void hasQuit()
    {
        Debug.Log("has quit game");
        Application.Quit();

    }
    

}
