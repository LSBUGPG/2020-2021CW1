How to code a Jump to the player 

Open a scene and add a plane and make this the ground, and add a cube and call this player. 
Add a Rigidbody to the player 
Move the camera to a position where you can clearly see the player. 
Right click in assets and go to create and click C# script, Name the script Jump

Now open the script and start coding. First at the top above 'Void Start' write 
public Vector3 jump;
public float jumpForce = 2.0f;
public bool isGrounded;
Rigidbody rb;

This code recognises the force of the jump we are going to add, it knows that the object is grounded and it sees the players Rigidbody that we added. 

Under 'Void Start' write 
 rb = GetComponent<Rigidbody>();
 jump = new Vector3(0.0f, 2.0f, 0.0f);
 This is the force of the jump that we are going to add, you can change the force to suit what you are making. 
 
 Write a new void called "Void OnCollisionStay()" and under it write  "isGrounded = true;"  This tells the player that when we collide with the ground to stay there until we tell it otherwise. 
 
 Under Void Start write  
 if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
rb.AddForce(jump * jumpForce, ForceMode.Impulse)
isGrounded = false;
This tells unity that if we press the spacebar on the keyboard that it will add a force to the player to make it jump into the air. 

Now we have done that we can add it to the player by clicking on player then going to components then scripts and then select the Jump script. The jump force is 2 currenrly but you can change that to what you like. 
