## Tutorial 5 - Gameover Menu

In this tutorial the gameover will be trigged by the timer system from the previous tutorial, although other things could be used for the trigger.

Create a new empty object, call it "gameover" and add it to the canvas. Add three buttons to it and lable them "Retry", "Main Menu" and "Exit". Create a new C# script and call it "gameoverScript". Add the script to the canvas. Inside this script first creat a new public GameObject and name it "gameoverUI". Save the script and then drag and drop gameover into the game object slot that will have opened in the inspector. This will be necessary for enable and disabling the gameover UI.

First we will need to check if the game is over. Do this with an if statement in void Update()
```
if (TimerSystem.timeRemaining == 0)
```
In this case we are checking in the value of the timeRemaining variable inside of the TimerSystem script from the previous tutorial is equal to zero. If it is we will trigger the game being over. To do this create a new function and call it "gameover()". This function will act almost same as the pause function in the pause menu, but will instead set the gameOverUI to active.
```
public void gameover()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.gameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
```
You will also need a function to load the main menu and quit the game when the corresponding buttons are pressed. Again these can be copied over from the previous pause menu tutorial, but with a key change. The load menu function needs the line "TimerSystem.timeRemaining = 1;" added so that the timer resets should the player try to play the game again. Finally a retry function is needed. Call this function "Retry()" and use the following code:
```
public void Retry()
    {
        Time.timeScale = 1f;
        TimerSystem.timeRemaining = 1;
        SceneManager.LoadScene("TestLevel");
    }
```
This will first unfreeze time, then reset the timer and finally loads the specified scene, which in this case is the only scene other than the menu. Two things to note: As with all previous scripts that have loaded scenes, the line "using UnityEngine.SceneManagement;" is needed. Additionally, it would be better to store the information of which scene you are currently on in a variable and use that when loading, rather then simply typing in the name of the level as done here. That way this would work with any scene. The final step is to add on click events to each of the buttons, and attach the appropriate functions.
