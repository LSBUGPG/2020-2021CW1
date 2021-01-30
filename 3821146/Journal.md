Learning Journal 

**02/11/20**
Making the camera apart of the player and at its height to look like a FPS - making the camera a child object of the player so it moves with the player 
No problems 

**03/11/20**
Tutorial 1 - Enemy AI pathfinding. Getting an object to patrol an area (walk around the area randomly) 

**04/11/20**
Character movement finished without any problems.
Using the mouse to look around worked for up and down but wouldn't look side to side 

The problem was a part of the code for the side to side mouse look (forgot the asterisk to times Axis, sensitivity and time.deltatime)
Looking works fine now

**06/11/20**
Getting the player to shoot projectiles out of a gun - put gun as a child of the player aswell and place it in the scene to look like the player is holding it 
Shoot whenever the mouse is clicked 

Problem - the gun only ever shot the one bullet. I had to make a manager that instantiated a prefab of the bullets 

**07/11/20**
Enemy chasing player tutorial. When the enemy is patrolling and sees the player, it stops patrolling and chases the player.

**08/11/20**
Creating the Enemy AI. Firstly, getting the enemy character to patrol (walk around randomly) an area. Using NavMesh to map out the area the emeny can walk around 

Problem - the NavMesh and enemy were falling through the area on start. I attached the NavMesh to the enemy as a child by accident, I removed it and set it as its own object (it worked)

Getting the enemy to spot the player, face the player, stop patrolling and start chasing the player when the player comes within a certain range 

Problem - the enemy would stop patrolling and then follow the player around very closely too quickly. I had to add a alterable speed and acceleration 
Problem - the enemy needs to stop following the player 

**10/11/20**
Adding in a way to kill the enemy by shooting it. Using the damage of the bullets shot by the player with the health the player has I was able to destroy the enemy 

Problem - the bullets didn't kill the enemy at first and had no damage. I added an empty game object with a collider and set the trigger, then coded an OnTriggerEnter on the enemy which allowed the player to kill the enemy 

Instead of killing the enemy to get it to stop following the player, I wanted to make it so if the player manages to outrun the enemy, the enemy will stop following the player and go back to patrolling.
Create a lot of If statements as to whether the player is out of sight or not 

**11/11/20**
Tutorial 3 - enemy attack. Once the enemy has spotted the player and is chasing them, when they are close enough (set parameter) they will attack the player (With projectiles?)

**12/11/20**
Now that the enemy stops following the player and has paremeters of whether it can see the player or not - I can add it projectiles for the enemy to shoot.

Problem - the enemy had no limit of how far away it can shoot the player, so when it saw the player it immediately shot. I had to create another parameter of when the enemy can shoot the player depending on how far away it is.
Problem - the bullets the enemy was shooting instantiated to the left and behind the enemy. I added an empty game object and placed it where I wanted the projectiles to come out of and added it to the code. 

**14/11/20**
Instead of killing the enemy and destroying its rigidbody, as the enemy will go back to patrolling if the player is out of sight - the shots from the player knockback the enemy from them (they go back to patrolling)

Problem - I want the enemies to be propelled through the air when they're knocked back. Problem not solved (only pushes them back) 

**16/11/20**
Problem - The bullets for the player are unlimited (as they're instantiated prefabs). I added public floats setting a limit of bullets allowed to be shot.

**17/11/20**
When the player runs out of bullets - there needs to be ammo crates to refill bullets 
Problem - didn't allow player to go thorugh object and bullets didn't refill. Had to add a collider that was a trigger and coded an OnTriggerEnter to refill bullets (changable set amount)

**19/11/20**
Now that the enemy can shoot projectiles and shoots the player at a set amount of distance, the players health needs to be lost when the enemy projectiles hit them.

Problem - the projectiles need to look like a cloud of smoke going throug the player (only damages him once) *Problem not solved yet.*

When the player does get hit and loses health, as I don't want health regeneration, there needs to be a way the player can get back health. 
creating a health crate was very easy as the ammo crate is exactly the same but with a few bits of code changed. 

**21/11/20**
creating a main menu - adding in the buttons and their functions. 
Problem - buttons didn't work at first but was becuase I had to add 'using UnityEngine scenemanagement' 

**23/11/20**
point and shoot minigame - crossheir sprite moved with the mouse but the cursor was still visible, fixed by bit of code to hide the cursor when in play 

**24/11/20**
restart button tutorial 

**26/11/20**
seperating stick minigame - coding a stick to grow along to z axis when mouse is pressed, pushing two cubes either side of it 
problem - the stick goes through the cubes even though there are colliders on each object -- problem not solved 

**27/11/20**
sorting minigame - sorting coloured squares into bigger squares with the same colour, easy to set up a drag and drop system 
problem - no winning parameter so I added in a restart button instead 

**28/11/20**
Programming project - putting together the tutorials to make a re-usable game package. The package would be Enemy AI

**29/11/20**
Programming project - Enemy AI that patrols, chases the player, then when close enough will attack the player, a restart button/call when the player dies

**30/11/20**
Restart button for 3DD project 
