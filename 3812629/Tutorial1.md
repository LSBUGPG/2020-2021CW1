## Tutorial One - Main Menu UI

This tutorial will cover the creation of a basic main menu. To begin, create a new canvas in the hierarchy. It can be found under UI. Under the canvas create a panel. In the image component of the of the panel, which can be found in the inspector, set the source image to none and the colour to a dark tone with full opacity. This will form the simple background of the menu.

Create an empty game object under the canvas and rename it to "mainMenu" this will contain the menu buttons. Under the mainMenu object add three "Button - TextMeshPro" Within each button is a text object that can be edited to label each button. For this basic menu, label them as "Play", "Options" and "Exit".

Now, create a new C# script and call it "mainMenuScript" and add it to mainMenu. This will control all the buttons. First add the line "using UnityEngine.SceneManagement;" as shown below.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
```
This allows the script to load different scenes. Delete "void Update" and "void Start" as they are unnecessary for this script. Next we will create a function to start the game. To do this type "public void" then the name of the function followed by () {}. In this case I will use the name "PlayGame". Inside the function add the line "SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);" as shown below. This will load the second scene in your project's build settings.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
```
Before it will work we will need to hook it up to the menu button, but first we will add the function to handle quitting the game too. It will look like this:
```
public void QuitGame ()
    {

    }
```
Inside this add the line "Application.Quit();" which will close the game. As this is not visible in the editor, only when the game is built, you can add the line "Debug.Log("Quit!");" to check that it is working in the consol. When you are done your script should look like this:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

```

Next we will attach these two fuctions to their associated menu buttons. Select the play button, in the inspector under the button component there will be a section that says "On Click()". Click the plus button to add a new On Click event. Drag and drop the mainMenu object into the box that says "None (Object)" Then in the "No Function" dropdown select mainMenuScript then PlayGame (). If you run the project and click on the button it will now open the second scene listed in the build settings. Note that if you have not added a second scene this will not work. For the sake of this tutorial I will be using a placeholder scene.

For the exit button, do this same process again but use QuitGame () in the on click event. The options button will be covered in the next tutorial.
