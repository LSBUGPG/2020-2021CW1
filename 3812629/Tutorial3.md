## Tutorial 3 - Pause Menu

In your game's scene create a canvas. Within this create an empty game object and name it "pauseMenu". Under this object add three buttons. Lable the first button "Resume", the second "Main Menu" and the third "Exit". Next create a script, name it "pauseMenuScript" and add it to pauseMenu.

First we will need to get reference to the UI. To do this create a public GameObject and call it "pauseMenuUI". Then save and drag and drop pauseMenu into the game object slot in the inspector.

Next we will need to create two function, one that will pause the game and one that will resume it. Call the first "public void pause()". The first line will be "pauseMenuUI.SetActive(true);" This will make the UI active and therefore visable. On the next line set the time scale to 0 to pause time, do this by typing "Time.timeScale = 0f;". Now that the game is paused it will be useful to create a variable to track this. Back outside of the function create a public static bool and call it "gameIsPaused" and set it to false by typing "= false".

Back inside the function, add a new line and set the variable you just created to true. This will be useful if we want to check if the game is paused later on. Next we will want to make the mouse cursor visable and movable. Do this with the following two lines "Cursor.lockState = CursorLockMode.Confined;" which allows the mouse to move anywhere within the game window, and "Cursor.visible = true;" which sets the cursor to be visable. The function should now look like this:
```
public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
```
Now we will need a function that resumes the game. To do this, simply copy the function you just made, rename it "Resume()" and set all the values to the opposite. It should look as below:
```
public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
```
We now have the functionality to pause and resume the game. Now we need to make that functionality usable. To do that, add a new if statement to void Update(). It should say "if (Input.GetKeyDown(KeyCode.Escape))" This will check if the escape key is being pressed. Note that you can use any other key, escape is just the one that I will be using in this instance. If escape is pressed we will want to run an if else statement to check if the game is already paused or not. For this we can use the gameIsPaused variable that was created earlier. if the game is paused run Resume(); else run Pause(); It should look as below:
```
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

```
The game can now be paused and unpaused by pressing escape. To make the resume button work, add an on click event to it, add pauseMenu as the object and Resume() as the function. To add functionality to the main menu and exit buttons you can use the same methods as described in the main menu tutorial.
