# Pick Ups And Score

This is the fourth and final tutorial in the series, it is assumed that you have completed the previous three tutorials at this point. This will focus on creating two scripts, one to allow pick up items to function
when the player touches them, the other to have a score system displayed in game that increases with the pick up items. The way this 
will work is by checking for collisions from the pick up prefab and if it detects the "Player" object then it increase a score system,
play a sound and finally destroy the pick up item.

## Setting Up The Canvas

This tutorial will require the use of the Unity Canvas system to set up the score system that will be displayed on screen. To start
select create inside the Heirarchy > UI > Text. This will automatically create a canvas as well as a Text UI object within that canvas, 
name the new Text object "Score". Select the "Score" object in the Heierarchy and then while having your mouse anywhere within the scene 
view panel press the "F" key which will adjust your scene view to show the new Text object inside the canvas. While still having the object 
selected press "W" to select the transform move tool and move the object around the screen to wherever you prefer, you can also adjust  the 
size, colour, font etc inside the Inspector window, do not forget to increase the width and height of the rect transform component if you 
increase the size of the text so it still displays on screen. Create a script and name it "Score", then drag and drop the script on to the
canvas.

## Score Script

### Using UnityEngine.UI

Open the "Score" script up in Microsoft Visula Studio. This script will not be very long but will provide the neccessary tools to get a functioning
score system, to start we will need to add to collection of systems that is used within this script at the very top. Standard unity C# scripts do not
come with the UI system so we will have to add it in, to do this underneath "using UnityEngine;" type "using UnityEngine.UI;", this will give us access
to UI class based methods, functions etc. If done correctly it should look something like this:

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
```
### Declaring Variables

We will only need two public variables for this script, the first will reference our Text UI object and the second will be a public static int that will act as the value that will be displayed as our score. Using the same method shown in the previous tutorials, create these two public variables (Remembering to make the int a public static int):
 - Text scoreTextObj;
 - int score;
 
 Once done it should look like this:
 
 ```
 public class Score : MonoBehaviour
{
    public Text scoreTextObj;
    public static int score;
```
The reason we make the second variable a public static variable is because this will allow us to access the int from another script and manipulate it's value from there.

### Start Method
Inside the start method the only thing we will need is to simply set the value of our score to start at 0 whenever we first play the game. To do this simply type "score = 0;".
```
 // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
```

###  Update Method
Just like the start method we only need one line of code that will update the value of the score on screen every frame and display it in game. To do this type "scoreText.text = " " + score;", this will display an empty text space with the value of score added within. Once done that is all we will need for the "Score" script and are ready to move on to programming the pickups, here is the full script to double check over with:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = " " + score;
    }
}
```

### Linking The Text

After the script has been made head back into Unity, once there locate the "Score" script within the canvas inspector window, Drag and drop the "Score" Text object into the empty slot marked "Score Text".


## Setting Up The Pick Up Items

It is preferable if you have an already prefab pick up item but if not simply create one using Unity's basic 3D shapes and as long as it has a collider that matches it's shape and has "Is Trigger" ticked it should be fine. Simply re-name it "PickUp" and prefab it using the same method shown in the first tutorial. It is not essential but for the purpose of adding a little extra to our pick up if you have an audio clip you would like to play when the items are interacted with this tutorial will include these steps, if not simply disregard them. If you have an audio clip you will need to add an empty GameObject to act as your storage for all audio sources, I simply named mine "Audio", once created add an "Audio Source" component to the object and drag and drop your audio clip into the "AudioClip" section of the component. Create a script called "PickUpScript" and add it your "PickUp" prefab. Double check the player GameObject has the tag of "Player" applied to it inside the inpector window, if not you can select the tag drop down at the top of the inspector window and either select the "Player" tag or select create and manually type "Player" into an empty slot then head back into the inspector and assign the new tag. Now all that is left to set up is the placment of your pick up items, place your prefab into your scene and duplicate it and place multiple prfabs arouns the scene in areas your player will be able to reach.

## Pick Up Script

### Declaring Variables

This will be another relatively short script, this part is only for the optional audio clip if you wish to add this, if not skip to the "OnTriggerEnter" method. Create a public "AudioSource" called "sound".
```
public class PickUp : MonoBehaviour
{
    public AudioSource sound;
```

### OnTriggerEnter Method

Scripts by default come with a start and update method but we will not need either so you can either delete both methods or leave them as they are and start from under the update method. Here we will make use of a method called "OnTriggerEnter" which checks for entry collisions, to do this type "private void OnTriggerEnter(Collider other)" and add the curley brackets if it has not be automatically done so for you. This now gives us use of the collsion method and a paramter we can use to reference collsions "other". Inside the curley brackets create an "if" statement and inside the the brackets type "other.CompareTag("Player")", this will run a check when the collision method is called to see if the other collider has the tag of "Player". If it does we want to do three things:

- Play our pick up sound (optional)
- Increase the score by 1
- Destroy the pick up object

To start with the optional sound type "sound.Play(0);", this will play the sound file assigned to the public variable. Next on the line below type "Score.score++;", this is where our public static int comes in to play from the previous script, this line of code accesses the script and the "score" variable and incriments it by a value of 1.0. Lastly on the line below type "Destroy(gameObject);", this will destroy the GameObject the script is attatched to, it's important to do this last to make sure the other lines of code are executed before this happens. If all is done correctly it should look like this:

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Play(0);
            Score.score++;
            Destroy(gameObject);
        }
    }
}
```

## Final Set Up

Head back into Unity, if you have chosen to follow the optional audio additon to the pick up prefab, locate the script inside the prefab and drag and drop the "Audio" object into the empty slot labelled "Sound", make sure you overide changes to effect all prefabs. This should be everything you need, you can now press play and move your player into the pick up objects which should now play a sound, increase the on screen score and be destroyed. I hope you learned something and ultimately enjoyed this four part tutroial.

