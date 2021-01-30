# Player Tutorial (2D)

## Make a new scene

1.) Open Unity and make a new scene, rename this scene to `Player2DTutorial` and make sure it is set to `2D`.
2.) Right click on the `Hierarchy` tab > `3D Object` > `Sphere` (You can use 2D Object but you will need a Sprite for it, but for this tutorial we will just go with 3D Object)
3.) Rename the `Sphere` to `Player` in the `Scene` tab just under the `Hierarchy`

(Important): Check if your Player's collider is 2D. If not, remove EVERY component that isn't 2D (Only Collider and Rigidbody).
In the `Inspector` tab, just add component `Circle Collider 2D` and `Rigidbody 2D`
If you are using a Sprite that is not a Box or Circle collider, you may need to use another Collider (Please do note that this is a tutorial, I recommend to follow through my steps instead as it can make the whole script not work).

## Configuring the Player

1.) Click on the `Assets` folder then `Right Click` inside the Assets folder, `Create` > `Folder`
2.) Name this folder as Scripts.
3.) Open the `Scripts` folder and then `Right Click` inside of it, `Create` > `C# Script`
4.) Name this Script as `Player`.

## Writing the Player script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    {
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start ()
    {   
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}

## Implement the Player script to the player

Once you have written the code, `Save` the Player script.
After that, go to your `Player` 3D object or 2D object; whichever is the player on your game.
In the `Inspector` tab, click on `Add Component` and type in `Player Movement` or whichever script name you use for your player's movement.
Test and see if the player is moving using the `WASD` keys.