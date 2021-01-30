# Top Down Player Movement


- For this tutorial we will be creating a player movement that is top down, this means we will be creating movement for up, down, lef and right. To start of we will need to insert one asset for the player, to do this you will need to go to **assets** followed by **import assets** this will allow you to pick your image for your player in the scene. 

- Once that is done we will drag the asset into the scene and name it **Player**. Under the **inspector** for the Player, we will add a **rigid body 2D** which will enable physics onto the object. Still under the inspector, we will adjust the **Gravity scale** to **0** so the player doesn't fall down and under **constraints** we will also freeze the rotation on the **Z** to make sure the player doesn't rotate. 

![Screenshot (15)](https://user-images.githubusercontent.com/72073841/98053880-86479100-1e31-11eb-97df-5062dab9b243.png)


- Once that is done, we go to **add component** and create a **new script** for the player movement. Double click and this will lead you to visual studio. 

- Into visual studio we need to remove the **start method**, instead will we add some **variables**. Now we need to define the movement speed, for that we will write our first line of code. We will create a public float, with the speed of 5. 


      public class PlayerMovement : MonoBehaviour
      {

      public float moveSpeed = 5f;


- And now we need to reference the **rigid body** since that is the component for the player, for that we will need to create a **public rigid body** and name it **rb** for short. This will be under **public float**. 

- Save the script by pressing **CTRL** and **S** at the same time, and now you will see that the **player movement** has two variables, one for the speed and one that is a empty filed for the **rigid body**. The **speed** can be adjusted by entering a certain number, this will alter the movement speed for the player. 

- In the empty field, we will **drag** the **rigid body** from the player under the **inspector** and slide into the empty box. This will link the componenet to the **player movement** which means we can move around the player. 

![Screenshot (14)](https://user-images.githubusercontent.com/72073841/98053782-4d0f2100-1e31-11eb-943f-0ce9956b857e.png)


- Back to the script, near the end of script under **void Update()** we will insert a function called **void fixUpdate()** This is executed on a fixed timer and it is not stuck to the frame rate like **update** is which is realiable when we are working with **physics**. 

- In the **void Update** we will insert this line of code to get the horizontal and the vertical movement and we are storing this in the **vector2** called **movement**. You will need to insert this at the top section of the script. 


       // Update is called once per frame
        void Update() 
       {

       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical"); 

       }
       

- In the **FixedUpdate()** we will need use the movement variable to move the **player**, to do this we will need to use the **rigid body**. The **rb.MovePosition** is a function that allows the **rigidbody** to move to a new position and makes sure it colldies with anything in the way. The position we want is the current **rb** plus **movement** to control the speed of the movement. **fixedDeltaTime** is a variable will make sure the speed stays the same.
 
      void FixedUpdate()
      {
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
      }

- Once this is set, we need to save and we should hit play. Our character should move around using the ** WSAD or the arrow keys**  in the scene!


