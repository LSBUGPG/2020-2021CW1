# PauseMenu

This tutorial will show you how to create a simple pause menu that freezes time when the code is called to pause the game and resume time when called to unpasue the game.

## 1. The PauseMenu Script

- Click on the `Canvas` in the hierarchy and create an empty object called `pause menu`. In the Inspector, create a new script called `PauseMenu` and open it up in visual studio.

- First of all we need to make two variables. One will be to check whether the game is paused or not throught the use of a `bool`. The second will be a reference to the `pause menu` gameobject e created. Under `public class` type:
```
public static bool GameIsPaused = false;
public GameObject pauseMenu;
```

- We will not be calling anything at the beginning of the game so we can delete the `public void Start` function entirely. The first thing we need to look for is if the right input is being activated to pause or unpause the game. We do this with an `if` statement and checking if a specific key is being pressed, in this case we are looking for the Escape key. Under the `public void Update` function type:
```
if (Input.GetKeyDown(KeyCode.Escape))
{

}
```

- Now that we have the input sorted, we can determine what happens when it is pressed in relation to the current state of the game (whether it is paused or not). In the `if` statement we just made we are going to make an `if` and an `else` statement to check if the game is paused or not using the `bool` we made earlier, and direct us to certain methods based on that answer from the `bool`:
```
if (GameIsPaused)
{
    Resume();
}
else
{
    Pause();
}
```
This will tell the script to run the resume method if the game is paused, and pause the game via the pause method if it is not already.

- Now we need to create these methods to do something when called. First of all, the resume method will deactivate the `pause menu` object, resume normal flow of time, and finally set the `bool` to see if the game is paused to false. The opposite is true for the pause method:
```
public void Resume()
{
    pauseMenu.SetActive(false);
    Time.timeScale = 1f;
    GameIsPaused = false;
}

public void Pause()
{
    pauseMenu.SetActive(true);
    Time.timeScale = 0f;
    GameIsPaused = true;
}
```
This means that if the game becomes paused then the `pause menu` object will become active (which will host the menu UI elements), time will freeze in game and the `bool` will be set to true since the game is paused.

- Save the code and return to unity and click on the `Canvas` in the hierarchy. In the Insepctor, drag the `pause menu` object into the pauseMenu section.
