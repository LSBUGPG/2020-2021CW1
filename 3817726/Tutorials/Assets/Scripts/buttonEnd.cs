using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonEnd : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene(3);
    }
}
