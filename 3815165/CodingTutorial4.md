# Health System Tutorial 
This tutorital will show you how to make a simple health system.
## 1. Creating a new scene 
- Begin this tutorial by making a new scene called 'Health System'
- Make an empty game object called 'Player' by right-clicking under hierarchy and create an empty game object. 
- In photoshop or any other art programs, make 2 hearts, one is empty and the other is fulled(you can fill the heart with any colours). In this case, I will use red colour for my heart.
- After this, make a folder called 'Art Assets' under the project window by right-clicking, then create, folder. Then import these 2 heart sprites in the folder.   
- After this, create a new UI canvas by right-clicking under the hierarchy tab, then UI, Canvas. Then we must change the UI scale mode to scale with screen size under 'Canvas Scaler(Script)'. This is to make sure that the UI will scale with the screen size of the game.
- Then create a UI image called 'Heart' under Canvas by right-clicking in the hierarchy tab, then UI, Image. After this, drag the red heart in the Source Image section under 'Image (Script)'.
- After that make 10 red hearts(The number of hearts depends on the character's health) in the scene.
- Then create a folder called 'Scripts' and inside that folder make a new script called 'Health' by right-clicking inside the folder, then create, C# script.

## 2. Coding part
### Creating Variables
- In the Script, type in 'using UnityEngine.UI;' near the top section of the script.
- In the new script, under Public Class, make a public int called 'health', we will be using this variable to control the number of red hearts of the player in the scene. After this make another public int called 'numOfHearts', this variable is used to control the number of hearts container(empty hearts) in the scene. Then create a public images array called 'hearts' to store the heart images. After this, create a public sprite called FullHeart to store the red heart sprite and finally make a public sprite called 'EmptyHeart' to store the empty heart sprite.

using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

public class Health : MonoBehaviour

{

    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


### Update Function
- In the update function, create a For Loop, we want to make this loop to carry on running as long as the variable i is less than the number of hearts(numOfHearts) in the heart array( which is 10). Also with each loop, We want to check if i is smaller than the number of hearts(numOfHearts) currently displays on the player, we do this by using an if statement. If i is smaller then we want the heart of i to appear, we do this by typing in 'hearts[i].enabled = true;' under the if statement. However, if i is bigger than the number of hearts(numOfHearts), then we want the hearts in the array to not appear, this is done by typing 'hearts[i].enabled = false;' under the else statement. 

- Then create another if statement to check if i is smaller than health then the heart sprite of i will show a full heart. However, if all heart images in the array with an index that is bigger than i will have an empty heart sprite. after this, we will have to make sure that the player doesn't have more health than he is supposed to have. We do this by making an if statement to check whether health is larger than the number of hearts(numOfHearts), if it is then we need to make health equal to the number of hearts(numOfHearts).


 void Update()
    {
    
        if (health > numOfHearts) {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {
            
            if (i < health){
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts){
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }
}

## 3. Putting everything together
- Add the 'Heath' script to the player by dragging it in the add components section of the player. 
- Change the Health to 6 and change the Num Of Hearts to 8 to under Health(Script), after lock the Inspector window so we can drag all the heart images to the array easier. Change the Num Of Hearts and the Health as you like to test out the code.
- Then drag the red heart inside the Full Heart slot and drag the empty heart to the Empty Heart slot under the Inspector window.
