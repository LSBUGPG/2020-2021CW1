# Tutorial II 


### Introduction 
In this tutorial, we are going to touch on throwing game objects across the scene. If you havent done it in Tutorial I or already got something to work with, I suggest to add some sort of box, large plane with colliders or other way of keeping objects when we throw them. 

### Dice 

In our example, we are going yo use dice model. You can model it by yourself, browse Asset Store for free models (there are plenty of those) or just add a cube for now (Game Object -> 3D Object -> Cube). 
Now, when we have the model or cube, we need to add few components to it. Lets start with **Mesh Collider** or **Box Collider** (make sure its not checked as trigger) and **Rigidbody**. 

![Components](/Tutorial%20II/Assets/Images/picture2.png)

Up next, we are going to need **Physic Material**. Its not a component, so create a new one in your assets folder. We are interested in **Friction** and **Bounciness** parameters. You can play with those later, for now set both frictions to around 0.1 and bounciness to 1. They affect how well your dice slides on board and how it bounces from surface. You will need to drag this material into Collider component on your game object, into Material slot.  

![Material](/Tutorial%20II/Assets/Images/picture1.png)


### Code

Yay, now we have a dice, but we need a way launch it. You can ahieve this by couple of methods, depending on your vision for the game. We are going to use Space button and **AddForce()** to throw it up. Alternatively, you may use **Instantiate()** to spawn dice from above and let them freefall or **OnMouseDrag()** to throw them by your mouse. Last one works way worse with multiple dice and jsut proven to be inconsistent option, but I will touch on it after we are done with **AddForce()** version. 

As always, lets start by creating new C# script and declaring variables. For just throwing, we need only one variable, and thats Rigidbody to hold our rb. However, you may need few more for future use. If you dont want space to be spammable, we are going to need bool, to chech if object is landed and int result to hold dice value in future. 

        Rigidbody myrb;
        public int result;
        bool landed = true;

In the **Start()** method, we are going to assign our rigidbody variable to actual component. 

        myrb = GetComponent<Rigidbody>();

Now, not much left to do. In **Update()** method we check for our button input and add force. One thing that is important for all cases - we have to add artificial randomized spinning speed, to add more variaty to dice values. We can do that by using **AddTorque()**. Now your code should look like this, + any optional checks for double pressing or being landed:


    public class Throw2 : MonoBehaviour
    {
        Rigidbody myrb;
        public int result;
        bool landed = true;



        {
            myrb = GetComponent<Rigidbody>();
        }

        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(landed)
                {
                    myrb.AddForce(Vector3.up  * 200);
                    myrb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
                }
            }
        }
    } 



### OnMouseDrag()

So, you are interested in this option. I would avoid it, unless its completely mandatory. 
Idea is to get dice coordinates, cursor coordinates and find vector between those two during muse drag, then apply force in direction of that vector. 
Cursor coordinates are different from object ones, though. They are so called screen coordinates, so use **WorldToScreenPoint()** to translate those. Also, you still need to add torque and potentially a check if object goes below your platform with this mouse drag. 
