# Tutorial IV


### Introduction 

Our dice-throwing game is almost done. We just need to assemble it and ad UI, because every application needs proper exit button, after all. 
In this tutorial we are going to display throw result on screen instead of console, add pause menu with reset and exit buttons and get our project together. 

### Throw Result

First of all, we are going to display dice value properly on screen. Lets start by creating **Canvas** (UI-> Canvas), where we can place all UI elements as children. 
Now, add **Text** object to the canvas. Lets create a new script now. This time we need new module before defining variables. At very top add:

    using UnityEngine.UI;
   
This will allow us to use UI elements. Now we can start defining. We are going to need GameObject to link the dice and Text to link our UI text field: 

    public GameObject ourDice;
    public Text txt;
    
Now we can take throw result from dice script and put it directly to the text field as UI. You should do this in **Update()** method:

    txt.text = "Result: " + ourDice.GetComponent<Dice>().result;
        
Save script, return to the scene and link your objects. 

### Pause Menu

Lets add more elements. First of all, we are going to need **Panel** (UI -> Panel) as child of **Canvas**. Everything for pause menu will be children of **Panel**. 
You can change colour and oppacity under the **Image** component, if you wish. 
Now, lets add 3 **Buttons** (UI -> Button). You shall rename them as Resume, Reset and Quit. Also change text for corresponding ones in child elements for buttons. 
Just as with panel, colour and oppacity may be changed in the inspector. Also you may change this for each state of the button, to make UI more responsive. 
Now, your hierarchy should look like this:

![Canvas](/Tutorial%20IV/Assets/Images/image3.png)

Now, lets get to code. We can do it in the same script with throw result. First of all, we are going to need one more module to reset scene:

    using UnityEngine.SceneManagement;
    
Now, we can add more variables. First of all, we need a bool to check if game is paused already. Also we are going to need game object to link our panel with buttons. 

    public bool pause = false;
    public GameObject menu;

The way we call our pause menu is rather easy. First of all, we disable panel in the inspector. Now, we can just enable panel if game is not paused to show it and disable again 
to hide. It should be done in **Update()**:

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

Now we need to add methods for buttons. Resume is literally same as closing pause with escape. For reset we are going to reload scene, taking everything to starting point. 

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


Now we can attach those methods to buttons. Save the script and return to menu. Look for the ivent table in the inspector menu for button. There you can add one with a "+". 
Then, drag canvas to empty slot and select your sript, then select corresponding method:

![Canvas](/Tutorial%20IV/Assets/Images/Image4.png)

Do it for every button. Now you have working menu for your dice-throwing game :3
