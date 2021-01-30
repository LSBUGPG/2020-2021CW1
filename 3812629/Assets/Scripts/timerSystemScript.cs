using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerSystemScript : MonoBehaviour
{
    public GameObject timerText;
    float timer = 1f;
    public static int timeRemaining = 1;

    private void Start()
    {
        timeRemaining = 5;
    }

    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1f;
            timeRemaining -= 1;
            timerText.GetComponent<TextMeshProUGUI>().text = "Time:" + timeRemaining;
        }
    }
}
