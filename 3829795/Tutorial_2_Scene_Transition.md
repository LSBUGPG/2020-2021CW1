# Scene Transition

This tutorial will show you how to switch to a different scene if your players walks into another object.

This tutorial requires you to have read my other tutorial teaching you how to get your character moving or having your own movement method.

## 1. Creating your transition object

You will first have to pick an object that will be your scene transition point that will move you to another scene when your player moves to it, you can use any shape but for this tutorial we will be using a sphere, so create a sphere by right clicking the “Hierarchy tab” , go to “3D Objects” and click “Sphere”, this will add it to your scene.
From there, move the sphere to a place where you want the transition to happen and then look to the “Inspector tab” and finds its “Sphere collider” there is an option that says “Is trigger” that is unticked, you’ll want to tick that so it can activate the scripts we will attach to the object, it also allows us to move our player through the object, making in intangible.


## 2. Create your script

Right click inside the box where your assets are and create a “Scripts” folder for all your further scripts. Double click inside that folder and right click to create your new script, call this script `SceneTransition` and double click it to open the script.
Once you’ve opened the script, you’ll need to add a different Unity Engine in order to switch between your scenes, underneath your last Unity engine at the top of your script write in `using UnityEngine.SceneManagement;` which will prep your script for scene transitions.
You will not be needing `void Start()` or `void update()` so either delete them or leave them.
Press under a few times to give you space under the second "}"/Curly bracket and write 
```
void OnTriggerEnter(Collider other)
{

}
```
“void” is just a way of saying function and you are creating a new function.
“OnTriggerEnter” means that when a collider enters the objects collider that this script it attached to, it will activate.
“(Collider other)” Is a way to specify a certain collider from activating the script, but by saying other it means that any collider will trigger this script.
The curly brackets mean that once the above states conditions are met, anything inside the curly brackets will happen.
Inside those curly brackets write
```
Scene.Manager.LoadScene(1);
```
“Scene.Manager” references the UnityEngine that we added at the top of the script
“LoadScene(1);” Is telling Unity what scene to load using the built setting within unity.
Your full code should look like this
```
void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
```
If it does then save it and check to see if you have any errors, if you do then go through the tutorial once more, checking for any capsulation or spacing errors.
Once you’ve bug checked everything, click and drag the script onto your sphere or object you have chosen as your transition point.


## 3. Create a second scene and build

Go back to Unity and right click the box that shows you assets and go to “Create”, find “Scene” and click that to create your second scene, you can call this level two or anything you’d like.
Once you’ve done that, go back to your starting scene and go to the top left of your screen where it says “File” and scroll down to where it says “Build Settings” and click that.
This will bring up a menu that will show you how to make a exportable build of your game, specifying the dimensions and platform, for now, we just want to add our scene to the “Scenes In build” table.
The is a button on this menu that says “Add Open Scenes” which will include the scene you are on in the table. 
Unity starts counting things from zero, which means your starting scene will be zero in the build index and your second scene will one which is why we specified to load scene one rather than two.
From there, it you should be able to play your scene, move your character to your transition point and you should transition to your next scene without any problem.

Thanks for reading!

