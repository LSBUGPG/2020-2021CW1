# 3D Enemy Arena Spawner
For this tutorial I will show you how to create a randomised enemy spawner that will spawn in enemies around the borders of a circle style arena, the way this works is by having an invisible object rotate around the edges of the arena and then using counters inside the code it will spawn enemies at random times on its position. For this to work first we will need to set up a few things in unity as well as make sure we have the following:
 - a 3D unity project with a level in the style of a circle or square arena.
 - An enemy Gameobject that we want to spawn, have this made into a prefab by dragging and dopping the object from the hierarchy into the project window.
   Make sure the enemy Gameobject has a Rigidbody and collider (prefferably a capsule), inside the constraints section of the Rigisbody freeze the y position and the
   x and z rotation axis.

## Unity Set Up
First thing we need to do is to create an empty gameobject that our enemies will spawn from, to do this:
 - In the hierarchy tab in Unity select create, create empty and name it "Enemey Spawner" and hit enter.
 - In the Inspector window select the cog wheel symbol in the top right of the Transform component, then select reset from the drop down menu.
 - Now position the gameobject at one edge of your arena by pressing "W" on the keyboard and dragging the axis arrows with the mouse inside the scene view.
 - Now that our enemy spawner has been created we need a second empty object to act as our centre point, repeat the first two steps however name this object "Centre Point".
 - Lastly Create a folder in the project window by right clicking in the window, create, folder and name it "Scripts", then inside the folder right click, create, c# Script and name it "EnemySpawner". Once finished double left click on the script to open it up in Visual Studio.
 
 ## The Code
 
 ### Declaring Variables
 
 The first thing you need to do is declare the variable that will be used within the script, lets start with declaring the Gameobjects, you will want these to be declared as public to access them outside of the script Under the class. Under the "public class" and above "void start()" type "public GameObject centrePoint, enemy;", if done correctly it will look as shown below. 
 ```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject centrePoint, enemy;
    
 ```
 Next you will need some private intergers to act as counters for three different tasks, write under your public variables "private int countToSpawn,countToRandomNumGen, randomTimerGenerator;". Underneath this you will also need a private float to control the rotation speed of your enemy spawner Gameobject, add this line under the intergers "private float rotateSpeed;". Overall the declared variables will look something like this:
 ```
 public class EnemySpawner : MonoBehaviour
{
    public GameObject centrePoint, enemy;

    private int countToSpawn, countToRandomNumGen, randomTimerGenerator;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
 
 ```
 
 ### Start Method
 
 Inside the start method you will want to make sure your variables are set to their starting values for the first frame upon hitting play, to do this write the variable name "=" and then the value you want it to be set at followed by a ";" at the end. 
 You will want both variables that start with "count" in their name to be set to 0, the rotate speed to be set to "0.5f" and the "randomTimerGenerator" to have this line of code added to it: "randomTimerGenerator = Random.Range(120, 600);", what this does
 is set the value of "randomTimerGenerator" to equal a randomly chosen interger between 120 and 600. Why 120 and 600? I will explain this in the update method below and the reason we set this in start as well as in updatate will also be explained below.
 
 If all is done correctly your start method should look something like this:
 
 ```
 void Start()
    {
        rotateSpeed = 0.5f;
        countToSpawn = 0;
        countToRandomNumGen = 0;
        randomTimerGenerator = Random.Range(120, 600);
    }
    
 ```
 
 ### Update Method
    
 This is where most of the coding will be done and now that you have everything set up above you can now use the variables you declared and set to get the enemy spawner working. Firstly you will want to start rotating the enemy spawner object around the edges of the arena using a fixed point of rotation which is where the centre point Gameobject comes in.
 Inside "Update()" write this line of code: "transform.RotateAround(centrePoint.transform.position, transform.up, rotateSpeed);", what this does is take the transform component on the object and have it rotate around the transform position of the centre point Gameobject at the speed set by the "rotateSpeed" variable. Once that is done you will also need to start
 increasing your "count" variables by a value of 1 per frame, to do this write "countToRandomNumGen++;" and underneath write "countToSpawn++;". The "++" symbol in C# is used as an incrementor that increases the value by 1 and since you placed it insed the update method it will do so once every frame, this acts as our counters counting up from the 0 value set at the start.
 
 #### If statements
 
 Now you will use if statements in order to put the last pieces together, the first if statement will check if the "countToRandomNumGen" is greater than or equal to 60, the reason we use 60 is because each frame the variable from 0 will get increased by 1 and 60 frames is the equivellent to 1 second in real time, therefore we want to run this if statement once every second hence 60.
 If the variable is greater than or equal to 60 then it will set the "randomTimerGenerator" variable to a new random number between 120 and 600. Just like with the "count" variables and the 60 frames a second the random number this variable will output will be the equivelant to anytime inbetween 2 seconds in real time (120) and 10 seconds in real time(600). Finally you will want to reset
 the "countToRandomNumGen" variable to 0 so in update it does not continue onwards form 60 which would in turn continously run this if statement as it will always be greater than 60.

To do this in code write the if statement as shown below:
 ```
 if (countToRandomNumGen >= 60)
        {
            randomTimerGenerator = Random.Range(120, 600);
            countToRandomNumGen = 0;
        }
  ```
  The second if statement you want will compare if the value of "countToSpawn" is greater than or equal to "randomTimerGenerator", if it is then spawn the enemy object at the enemy spawners transform position and do not adjust its rotation, then set "countToSpawn" back to "0". After that you will need a final if statement inside of the "countToSpawn" if statement that checks if the "rotateSpeed" variable is less than or equal to "22.4f"
  and if it is then increase the value by "0.3f".
  
  To do this in code write the if statement as shown below:
  ```
    if (countToSpawn >= randomTimerGenerator)
        {
            countToSpawn = 0;
            Instantiate(enemy, transform.position, Quaternion.identity);
            if (rotateSpeed <= 22.4f)
            {
                rotateSpeed += 0.3f;
            }
        }
   ```
   
   If you have followed all above correctly your script should like something like this:
   ```
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject centrePoint, enemy;

    private int countToSpawn,countToRandomNumGen, randomTimerGenerator;
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 0.5f;
        countToSpawn = 0;
        countToRandomNumGen = 0;
        randomTimerGenerator = Random.Range(120, 600);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.RotateAround(centrePoint.transform.position, transform.up, rotateSpeed);

        countToRandomNumGen++;
        countToSpawn++;
        
        if (countToRandomNumGen >= 60)
        {
            randomTimerGenerator = Random.Range(120, 600);
            countToRandomNumGen = 0;
        }
        if (countToSpawn >= randomTimerGenerator)
        {
            countToSpawn = 0;
            Instantiate(enemy, transform.position, Quaternion.identity);
            if (rotateSpeed <= 22.4f)
            {
                rotateSpeed += 0.3f;
            }
        }
    }
}
```
### Connecting The Pieces Together

Once done you can save your script by holding in "ctrl" and pressing the "S" key and then going back into Unity. The last thing to do is simply drag the script from the scripts folder and drop it onto the enemy spawner Gameobject, once there find the script inside of the objects
inspector window and you will need to make the reference linkway between the enemy spawner object and the "centrePoint" and "enemy" Gameobjects you publicly declaired at the top of your script. To do this simply drag and drop the centre point Gameobject found in the heirarchy into the 
empty slot on the enemy spawners script component, then locate the enemy prefab in the project window and drag and drop it onto the other empty slot on the enemy spawners script component. Now that everything is set up the last thing to do is simply select the play button at the top of the scene view and
marvel at your new fully functioning randomised enemy spawner.
 
