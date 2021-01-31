# Making a Deadly Hazard

This tutorial will show how to set up a hazard that will restart the scene you are on if the player runs into it, a "Game Over" function.

This tutorial requires you to have read my other tutorial teaching you how to get your character moving as the code responds to Unity's character controller,

## 1. Setting up your Hazards

FIrst thing you will need to do is decide what hazard you want in your game, if you don't already have a sprite or object then you can use a shape in Unity, I will use a cube as my hazard for this tutorial so you can too, place the cube where you'd want it to be in your scene.

Now you will need to make sure that your hazard is tagged as such so any other hazard you add to your game will be affected by the same code we will make. Go to your hazards inspector tab where you can see your game objects tag, it should be untagged right now. Click that and you will be brought to a menu where you can create your own tags by clicking the plus sign, click that and name your new tag “Hazard”.


## 2. Create your script 

Now you need to set up your script, right click the box where you see your assets and go to create and script, call it “HazardLoss”. Once visual studio open you will not need `void start()` or `void update()` so either delete or leave them. You will also need to add a “Unity Engine” called “Scene.Management” which will tell Unity that you will be using code that uses scenes, the engine writes like this:

```
using UnityEngine.SceneManagement;
```

To make your reset script you will need to reference your controller’s collider as that will be what activates your script, to do this you write:

```
void OnControllerColliderHit(ControllerColliderHit hit)
	{
	
	}
```

This will reference the character controller’s collider as Unity’s character controller has its own collider separate to your game objects collider. 
Inside the curly brackets, we will need to check if the player has hit the hazards collider, to do so we write

```
if (hit.gameObject.tag == "Hazard")
	{
	
	}
```

We will be attaching this script to our player because we want to check if the character controllers’ colliders hits anything with the tag “Hazard” and if it does, we will reset the scene.
In order to reset the scene, we must reference the Scene manager in the Unity Engine and load the same scene we are currently on, we want to do this rather then naming the scene we want to load because we want to be able to use this reset script for multiple levels in case your game has more then one level. This uses Unity’s build index which is a function that allows you to make executables builds of your game like you published it, you write the following in the second set of curly brackets to get this function:
```
SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
```
This finished code should look like this:
```
void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
```
Check to see if you have any errors, if you do not then be sure to go over the tutorial again. 
Go back to Unity once everything is ok, click and drag your script into the players inspector tab to attach the script to the player.


## 3. Get your scene in the build Index

Now that we have all the script ready, we will need to add your scene to the build setting in Unity.
Go to file at the top left of Unity where it says “File” and scroll down to where it says “Build Settings” and click that. This will bring up a menu that will show you how to make a exportable build of your game, specifying the dimensions and platform, for now, we just want to add our scene to the “Scenes In build” table. The is a button on this menu that says “Add Open Scenes” which will include the scene you are on in the table. 
Now if you play your scene if you run into the hazard, the scene should reset and your character should be back at his starting position.

Thanks for reading.
