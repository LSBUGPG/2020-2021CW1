# Tutorial III

### Introduction

This is third tutorial, in which we will determine on which side object landed. Many things were created in tutorial II, so check it first. 

### Adding triggers

In last part we made a dice, but now we want it to react somehow to the ground. To do that, we are going to use other game objects as triggers. Those can be of any form - cubes, 
cones or even planes with small raycasting. We are going to use spheres. Create one object as a child of a dice, scale it down and place in the middle of the dice side.
It should be rather small, 
otherwise occasional accidental triggers may happen and produce incorrect results. 
Since we don't want our cube to be covered by additional meshes, turn off **Mesh Renderer**. Also, add collider and check "is trigger" as true.
Lastly, you can dublicate those and set
on each side. This should look something like example:

![Dice](/Tutorial%20III/Assets/Images/Image1.png)

### Code for Triggers

Now, we can start working on code. First of all, we need small scripts for each of those invisible sides. As usual, create empty script and lets add variables. 
We are going to neeed bool to check if trigger touches the ground and int value for the side:

    public int value;
    public bool onGround;

Since our dice may roll wildly and touch ground with trigger few times before final result, we are going to use **OnTriggerStay()**. 
If you are adding code for registering multiple rolls values, you need to do that after dice has stopped, since all interactions may get recorded.
Also, you may want to add tag for your ground object and check if object triggered touched is tagged as ground. 
In our example there is only one object to touch, so we dont need it.
Our small script should look like this:

    public class Side : MonoBehaviour
    {
       
        public int value;
        public bool onGround;

        private void OnTriggerStay(Collider other)
        {
            onGround = true;
        }
        private void OnTriggerExit(Collider other)
        {
            onGround = false;
        }
    } 
    
 Now, return to the scene and add script to each of the children for our dice. Also, you need to enter value for each of them. 
 *Remember that value dice is going to show is opposite to which it lands on.*


### Code for Dice

Code section here is not large either. If you want to, you may include it to the throw script from last tutorial or create a new one and attach it to the dice. 
We are going to neew 2 variables - int for result of the throw and GameObject[] list for the sides that our dice has. (I hope you are not making d100 with this tutorial). 

        public GameObject[] sides;
        public int result;

Go to the scene and drag each of the children to slots in our list. Since we are not going to need **Start()** method, you may delete it. 
In **Update()** we check for each of the sides if it touches the ground. If yes - we record its value. For now lets just print it to the console. 
This part of the script should look like this:

        void Update()
        {
            foreach (GameObject i in sides)
            {
                if (i.GetComponent<Side>().onGround == true)
                {
                    result = i.GetComponent<Side>().value;
                    print(result);
                }
            }
        }

Go back to main scene and throw your dice couple of times to check if values correspond images.
