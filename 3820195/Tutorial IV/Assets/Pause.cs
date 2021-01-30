using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

    public bool pause = false;
    public GameObject menu;
    public GameObject ourDice;
    public Text txt;

    // Update is called once per frame

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                menu.SetActive(false);
                pause = false;
            }

            else
            {
                menu.SetActive(true);
                pause = true;
            }

           
        }


        txt.text = "Result: " + ourDice.GetComponent<Dice>().result;
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        menu.SetActive(false);
        pause = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
