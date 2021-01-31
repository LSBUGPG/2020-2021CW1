13/10/20
How to make player move endless in unity

Create new scene 
Make a cube object and name it 'Player'
Make a plane surface for the player to move on and name this 'ground'
Add a Rigidbody to the player
Now make a script and call it 'Player Move' 
Now we are going to write the script. We are going to write under "void start"  rb = GetComponent<Rigidbody>(); . This recongnises the player rigidbody
Next in void Update we are going to put in a bunch of code. 
  if (Input.GetKey(KeyCode.LeftArrow))
        {
            PushLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PushRight();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PushUp();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PushDown();
        }
            
            All this code does is tell unity that if I press the Right arrow key on my keyboard it will move right and then if I press the up arrow it will move up etc
            Now add a "void PushUp()" 
           Inside this void you write  rb.AddForce(0, 0, MovementForce, ForceMode.Impulse);  this code tells unity to add a movement to the character, as this code is for making a playyer move endless we do not need code to make the player stop when we take our finger off a key going forward. 
           you write this for void PushDown, void PushLeft and void PushRight. By doing all these it tells unity to move left, right, up and down while moving. 
           
           Now we have the script, we need to add it to the player. Click on the player and go to the right side of the screen to the inspector and scroll down to "add component" and go to scripts and then select the PlayerMove script. 
           If the movement of the player is too fast, you can edit the movement speed to go a speed you want. 
            
           
         

