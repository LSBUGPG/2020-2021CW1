# Learning Journal

29/09/20

I have learnt a lot about github and its capabilities for helping me keep my work organised and updated along the course. 

Today's task of creating instructions to draw a simple drawing has shown me how people (and essentially computers) interpret something differently based on the wording and detail that is provided within the instructions. Even with simple images consisting of 12 or less lines can present a large hurdle when describing exactly how it is drawn in a step by step basis. This has urged me to be more thorough when working with instructions or scripts such as coding and programming.

13/10/20

Today was the start of the tutorial CW1 assignment for programming. To make it easier and efficient I decided to work on code that would be used within my 3DLD module. The first being creating a script to make a first person player look in the direction of the mouse. 

The code was reasoanbly simple to follow along and I was able to create the script by the end of the lecture and apply it to my 3DLD game as well. I worked on creating draft notes for the tutorial on how to create it before making them properly.

Some parts of the code were very interesting and involved things I definitely didn't know. One such thing was the use of `Mathf` and `Clamp` to make sure that the player cannot look all the way behind them along the x axis. 

16/10/20

Today I worked on my second tutorial, in tandem with the first one this also affected the player object, but this time it was to get the object to move when input was supplied. It was quite interesting to see how simple this code was to do in the end, as unity has already linked the common movement keys to the `Horizontal` and `Vertical` references that cut down on the code a lot.

20/10/20

This was a more productive day than the last week as I was able to create the second tutorial as well as the third one which was a toggable torch connected to the player. This was also used in my 3DLD project as at one stage of the game the lights go out and the player needs a personal source of light to move around.

27/10/20

The last tutorial was about making a pause menu, which for the tutorial was easy enough since I did not have to include have the complicated code that I did with my 3DLD project. This is why it took quite a long time to test the script since I was testing it in my 3DLD project and having to create the UI and make sure that everthing worked smoothly. 

It is an interesting script to use, it was one of the first that I used with seperate methods being called when something was true or false. The addition of UI elements as well was challenging to say the least to make sure that all of the buttons work and went to the proper places and scenes. This was helpful for when I created my main menu as well, since it did have some of the same logic, although I found the main menu to be more fun to create, probably because I had an idea of how menus worked.

03/11/20

This lecture I used to create the draft tutorial for the pause menu which was simplified with the absence of UI elements and everything else that made it challenging in my project.

10/11/20

I read over my draft tutorials and decided to refine them into actual proper tutorials with detailed step by step instructions. I decided to try these out in word at first as I am still a little unsure of how to operate with github as a whole. 

With the tutorials complete, I am able to focus on the four scripts working together which is set for programming CW2. I ahve had a number of ideas of what to do for the scripts but I will have to look into how they work.

17/11/20

I spent the lecture looking at navmesh tutorials online. I am still very unsure on how thwy work at the moment, and the few attempts I've tried to do have all failed with disaster, in that the object patrolling the navmesh suddenly gets caught at an angle and proceeds to jolt around furiously in one spot.

24/11/20

I spent even more time looking at multiple AI tutorials involving navmesh to try and see if I could get a different angle at it. After a little while of searching I did find a good waypoint system that acted as a patrol that did happen to work where the navmesh failed. I was able to get an enemy to patrol four waypoints across a plane in an order. It is a step in the right direction, since now with a working patrol I can now work on my second planned script of the enemy chasing the player if her comes close.

01/12/20

I started with looking for more navemsh videos just to make sure I didnt miss anything with it but each time still resulted in the same outcome of the patrol not happening at all. 

I worked on a chase script that utlized the navmesh to navigate a path to the player although I ran into a problem where the patrol would work, then the player would get in range of the enemy and it would just stop. I moved the player out of the area and the enemy just remained there, unmoving. In the code it should have for one chased the player object but also returned to the patrol if the player was not in range. I studied the code for a while to try and understand why this was occuring but I couldn't find anything that would have been causing this behaviour. I probably missed something obvious like a component but according to the videos I watched on it I was doing basically the same thing.

08/12/20

I decided to give the navmesh one more try before the christmas break to see if I could hopefully find out why it was not working. Unfortunatley a lot of the videos that I could find on the idea of 3D navmesh was apparently 2D enemy behaviours for some apparent reason or behaviours that were not useful in the scene I as trying to create.

16/12/20

I decided to leave it there for a while and try to come back to it much later with fresh eyes and hopefully find the fault that was stopping it from happening. But the navmesh was starting to look like an idea that I might not use in the end with the amount of time I spent trying to get it to work but failed to. 

07/01/21

I decided to drop the patrol on a navmesh or towards waypoints completely and focus on a new behaviour. I thought it would be cool to look into raycasts and thought of a rotating enemy in the middle of the map that has a raycast coming out of him like a line of sight that could detetct things. I looked into rotating enemies and raycasts in 3D objects and had to combine a 2D script with a 3D one, but I did manage to get the script working eventually.

There were a number of problems to start with, but the main one was the bizzare property of the enemy recognising the player but also not at the same time. To put it shortly, I managed to get the enemy to rotate on the spot and send out a raycast that changed colour from green to red if if was hitting something (whether that be a wall or the player). I wante to maked sure that the enemy was indeed seeing the player and to make an eventual way to link two scripts together. However, using the print tool, I quickly found that the enemy was noticing the player as an object but not the player.

After a lot of headscratching and tweaking of the code, along with a little bit of help, I realised that all i was missing was a rigidBody component on the player. After the addition of that component, the script worked perfectly.

08/01/21

With the rotating scan working, I decided to work on the next script, being the chase the player script. I watched several AI chase tutorials and went for the ones that came up the most in videos. I did also utilize the raycastng from the previous script to help with this one as well. But in the end I managed to get the enemy to follow the player if the raycast hit it.

15/01/21

With the chase working, I needed to add the next script which was to reset the enemy to its original position and continue roatting if it lost sight of the player. I used the raycast again to detect if the player was out of sight and used a way point to set the position of where the enemy would return to. It worked smoothly the first time which was very surprising but was definitely welcome. 

I quickly added a destroy object and reset scene code into the script to finish it with killing the player on contact and resetting the scene if that happened.
