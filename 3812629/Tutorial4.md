## Tutorial 4 - Time Limit

This tutorial will cover creating a time limit. The tutorial after will go over connecting it to a gameover screen.

First create a new Text - TextMeshPro and add it to a canvas on your scene. A regular text object can be used instead, but I will be using text mesh pro for this tutorial. Next create an empty game object and name it "timerSystem". Then create a new script, call it "timerSystemScript" and add it to timerSystem.

First create a new float variable to count down the time, and a public static int to keep track of the time remaining.
```
float timer = 1f;
public static int timeRemaining = 1;
```
Now inside of void Start() set the amount of time you want to have in the timer. I will use 5 seconds in this case.
```
timeRemaining = 5;
```
Inside void Update() add the line "timer -= 1 * Time.deltaTime;". This will count the timer variable down by one per second. However it will also count down all the decimal points too, which looks messy. This is why we need two variables, a float is needed to keep the countdown consistant across framerates, and a int is needed to make the text display clear.

Next add an if statement. Check "if (timer <= 0)" then if that is true "timer = 1f;" and "timeRemaining -=1;". This will reset the timer so it counts down another second, and reduce the time remaining by one.

The final step is to connect this to the text mesh pro created at the start. Create a new variable "public GameObject timerText". Save and then in the inspector add the text mesh pro object into the new game object slot. Now add a new line into the if statement "timerText.GetComponent<TextMeshProUGUI>().text = "Time: " + timeRemaining;" This will get the text from the timerText game object change it to say "Time:" and then the value of the timeRemaining variable. It should be noted that if you are using text mesh pro you will need to add the line "using TMPro;". The script should look like this:
```
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
```
