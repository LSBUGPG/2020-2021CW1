Step 1:

Create a script in unity by right clicking in your assets folder and choosing create. Choose C# script and name it PlayerMovement/Player_Movement/PlayerMove etc

Step 2:

Make a public variable like this:

  public CharacterController controller;
    //This will allow us to change the variable in the inspector

Make another public variable like this under the controller variable:
  
  public float speed = 12f;
    //This will be used to adjust the speed of your character.
    
Your code shoulkd look like this:

  public CharacterController controller;
  public float speed = 12f;



Step 4:

In the void update add this:

    float x = Input.GetAxis(“Horizontal”);
      //This allows you to move left and right as those directions are linked to the X axis.
    float z = Input.GetAxis("Vertical");
      //This allows you to move forward and back as those directions are linked to the Y axis.
      //Unity's has in built key bindings, these are WASD(W=forward, A=left,S=back,D=right)and the arrow keys.
    Vector3 move = transform.right * x + transform.forward * z;
      //telling Unity that we want the gameobject that this script is attached too to move in the axis we have referenced.
    controller.SimpleMove(move * speed)
      //Applies physics and a numerical amount for speed to our object.
    
The code should look like this:

  void Update()
      {

          float x = Input.GetAxis("Horizontal");
          float z = Input.GetAxis("Vertical");

          Vector3 move = transform.right * x + transform.forward * z;

          controller.SimpleMove(move * speed);
      }


Step 5:

Go back to unity and apply this script to your player. If no errors occur then you should see it show up in the inspector.

In the inspector tab, add a character controller component to the player. You should have a character controller you can drag into the script in the inspector.
