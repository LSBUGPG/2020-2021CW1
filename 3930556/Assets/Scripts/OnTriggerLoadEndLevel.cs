using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerLoadEndLevel : MonoBehaviour
{
    public GameObject enterText;
    public string levelToLoad;
    void Start()
    {
        enterText.SetActive(false);
    }

    private void OnTriggerStay(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            enterText.SetActive(true);
        if (Input.GetButtonDown("use"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            enterText.SetActive(false);
        }
    }
}
