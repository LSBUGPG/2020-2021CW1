# Player Movement
This is the third in a four part tutorial series and if you are reading this, I am under the assumption that you have completed the two previous tutorials. Within this tutorial
we are going to give the player GameObject movement by detecting inputs and applying force to the player GameObject.

## Unity Set Up
To get started all we will need to do is give the player GameObject that should already be inside the scene from the previous tutorial, using the method shown in the previous
tutorials create a script within the "Scripts" folder and name it "PlayerMovement". As stated above you should already have the player GameObject due to the previous tutorial
requiring one, heres a quick check list of all components the GameObject should contain within the inspector window just to be sure:

 - Transform
 - Mesh Filer (only if using standard unity shapes for prefab model)
 - Mesh Renderer
 - Capsule Collider
 - Rigidbody

Once every thing is in place simply double click the script to open it up in Microsoft Visual Studio so we can begin going through the programming.

## The Code
### Declaring Variables

As shown in previous tutorials we will need to declare the variables we want to use for our script first. By now you should be familiar with where the variables go and how they
should be formatted, using the same method declare the following variables:

- public float speed;
- private Rigidbody rb;
- private bool forward;
- private bool backward;
- private bool left;
- private bool right;

If positioned and formatted correctly it should look something like this:

```
public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;


    // Start is called before the first frame update
    void Start()
```
### Start Method

Inside the start method we arew going to create the linkway between our private Rigidbbody variable and the component within the inspector, to do this we use a function known as "GetComponent". Type "rb = GetComponent<Rigidbody>();" and this will create the link between the two. Last thing to do within the start function is to set the states (we want them to be false) at which the booleans will start with when the script first runs, to do this simply type out the boolean names and type " = false;" after tyhe name. Here is an example of the first boolean: "forward = false;", using this method and example fill out the rest of the boolean states, once complete it should look something like this:
 
 ```
     // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = false;
        backward = false;
        left = false;
        right = false;
    }
```

### Update Method

Here inside the update method we are going to check for key inputs that will determain which direction we want force to be applied to the player moving it into the corrospionding direction. To do this we will need to make use of a bunch of "if" statements and set the booleans within them accordingly. The most commonly used set of key inputs for player movement by todays games are "W,A,S,D". So the first thing we will need to check for is input, to do this type  "if" and tap the "Tab" key twice which will format the syntax of the "if" statement for you, then fill in the brackets of the "if" statement with this "(Input.GetKey(KeyCode.W))", this will check for continous input from the "W" key using the "GetKey" function. Inside the curley brackets ("{}") type "forward = true;" which will set the boolean to true when this condition is set. Now that we have set up the "forward" boolean to true under the correct condition we will also want a very similar condition that simply turns it back off again when the there is no registered input with the "W" key. To do this copy the same "if" statement we just created and paste it on the lines below, once done simple add a "!" before "Input" inside the brackets and then change the boolean inside the curley brackets from "true" to "false". This will make sure the boolean is set to "false"  when the condition is not met. Now using the same method as shown above to set up both the input check and non input check for the "W" key, do the same with the "A,S,D" keys making sure you use the "left" boolean for the "A" key, "right" boolean for the "D" key and "backward" boolean for the "S" key. Once finished if done correctly it should look something like this:

```
   // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            forward = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (!Input.GetKey(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        if (!Input.GetKey(KeyCode.S))
        {
            backward = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            right = false;
        }

    }
```

### FixedUpdate Method

We will want to use the "FixedUpdate" method to help handle our physics calculations better, to get this method set up within Visual Studios just under the "Update" method type "private void FixedUpdate()" then Visual Studio should automatically add the curley brackets if not simply add them in. We are going to use another series of "if" statements and to adjust the forces applied to the player as well as the value of drag applied to the "Rigidbody" component to control the sliding effect when moving.

#### Forwards and Backwards

The first "if" statement will simply set the drag value for when no input from any of the keys is being registered, we want to up the drag here so when the player is moving then lets go of the input the new drag value is applied to assist in slowing the player down. Type "if" then tap "Tab" tweice to get format the statement and inside the brackets type"!forward && !backward && !left && !right", this will make sure all booleans that check for input are not true. Inside this new "if" statement to set the drag simply type "rb.drag = 6f;", once done it should look like this:

```
if (!forward && !backward && !left && !right)
        {
            rb.drag = 6f;
        }
```
On to the next "if" statement we want which will check to see if the "forward" boolean is set to true, if so then we will adjust the drag again as well as apply force in the forward direction of the objects transform component. To do this using the same method above create an "if" statement and inside the brackets type "forward" which will check to see if this boolean is true or not. Inside the curely brackets type "rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);" and underneath type "rb.drag = 1f;". The first line will apply force to the objects forward transform using the "AddForce" function mulitplied by the "speed" variable that will be set later on which is then multiplied by "Time.fixedDeltaTime" and finally the force mode is set to "ForceMode.Impulse", this will apply the force instantaneously rather than gradually over time. The second line simply changes the drag value back to 1 while the object is moving otherwise if left on 6 would slow it down considerably.

```
if (forward)
        {
            rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.drag = 1f;
        }
```
The next "if" statement will focus on moving the object in the opposite direction from the "if" statement we just made to make the object move backwards. To do this either re-type out the "if" statement as shown above or copy and paste the above statement on the line below and change"forward" to "backward", then simply add a "-" before "transform.forward". Everything else can stay as it is above, this will now check the condition of the "backward" boolean and if true will apply negative force to the forward direction of the transform component essentially moving the object in the opposite direction.

```
if (backward)
        {
            rb.AddForce(-transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.drag = 1f;
        }
```

#### Left and Right

Now we are going to address the left and right forces that will be applied to the object, this will be handled slightly diiferently to the previous two, we will want to rotate the object towards the corrosponding direction to turn the object left and right. We also want to check if the object is moving forwards or backwards, if so simply apply forces to push the object in the correct direction.

To start lets go ahead and set up an "if" statement and in the brackets type "left", inside the curely brackets type "transform.Rotate(0,-2f,0, Space.Self);" and on the line below "rb.drag = 6f;". This will check the condition of the "left" boolean and if true will roatate the object by a value of -2 along Y axis, then using the "Space.Self" function will set the transformation of the object relative to it's local co-ordinates, finally the drag value is set for the same reasons as shown in the above statements.

Now we are going to create a second "if" statement inside the current one just below the line in which we set the drag value. Inside the brackets for this new "if" statement type "forward || backward", then inside curley brackets type "rb.drag = 1f;" and on the line below "rb.AddForce(-transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);". This will check to see if while the "left" boolean is true if the "forward" or "backward" boolean is also true, if so then the drag value will get set as well as force being applied to the left of the objects transform multiplied by the speed variable and with the force mode being once again set to "Impulse".

```
if (left)
        {
            transform.Rotate(0,-2f,0, Space.Self);
            rb.drag = 6f;
            if (forward || backward)
            {
                rb.drag = 1f;
                rb.AddForce(-transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
```
Lastly we need to incoporate moving right and just like moving backwards we can simply copy and paste the same statement made for moving left and make a few changes, those changes being in the brackets having "right" instead of left, inside the curley brackets removing the "-" from "transform.Rotate(0,-2f,0, Space.Self);" and finally removing the "-" from "rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);", if done correctly it should look like this:
```
 if (right)
        {
            transform.Rotate(0, 2f, 0, Space.Self);
            rb.drag = 6f;
            if (forward || backward)
            {
                rb.drag = 1f;
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
```
This completes what you will need for your "PlayerMovement" script, here is what the entire script should look like if followed correctly:

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private bool forward;
    private bool backward;
    private bool left;
    private bool right;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = false;
        backward = false;
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        if (!Input.GetKey(KeyCode.W))
        {
            forward = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (!Input.GetKey(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }
        if (!Input.GetKey(KeyCode.S))
        {
            backward = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if (!Input.GetKey(KeyCode.D))
        {
            right = false;
        }

    }

    private void FixedUpdate()
    {
        if (!forward && !backward && !left && !right)
        {
            rb.drag = 6f;
        }
        if (forward)
        {
            rb.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.drag = 1f;
        }
        if (backward)
        {
            rb.AddForce(-transform.forward * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.drag = 1f;
        }
        if (left)
        {
            transform.Rotate(0,-2f,0, Space.Self);
            rb.drag = 6f;
            if (forward || backward)
            {
                rb.drag = 1f;
                rb.AddForce(-transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
        if (right)
        {
            transform.Rotate(0, 2f, 0, Space.Self);
            rb.drag = 6f;
            if (forward || backward)
            {
                rb.drag = 1f;
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
    }
}
```

### Setting The Speed Up

Head back into Unity where we will now set-up the speed for the object, inside the project window locate the "PlayerMovement" script inside the "Scripts" folder and drag and drop it on to the "Player" object in the Heirarchy window. Click on the "Player" object and locate the script inside the Inspector window. Inside the script component there should now be a public "Speed" variable, increase this value to whatever feels right for your game but for the sake of this example I found 50 to be a good value. Once set simply press play and try out your new movement script adjusting the "Speed" value to your liking.
