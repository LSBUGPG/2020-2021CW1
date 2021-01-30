using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0;
    float startTime = 15f;
    public Image timer;
    public Bandit Player;
    public bool StartTimer = false;
    public GameObject timerParent;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        timerParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer == false)
        {
            return;
        }
        timerParent.SetActive(true);
        currentTime -= 1 * Time.deltaTime;
        float s =  (currentTime / startTime);
        timer.fillAmount = s;
        if (s < 0)
        {
            Player.StopFiring();
            StartTimer = false;
        }
    }
}
