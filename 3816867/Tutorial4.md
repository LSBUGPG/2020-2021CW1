How to respawn player with a key on keyboard
03/11/2020

To start create a new unity file. Once its opened create a plane.
Now make another cube and call this "character"
Add a Rigidbody to it 
First we can add the endless movement code to the character again. 
Set the movement speed to 0.2
In the same code, under Void Start write 

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

This tells unity that when we press the "R" key on the keyboard it reloads the level from the beginning.
Once we have the code, make sure there is no compile errors, if there is then a bit of code is slightly wrong or something maybe missspelt.
Now we can add the code to the player, once thats done press play and when you press R the player should reset to the beginning. 
