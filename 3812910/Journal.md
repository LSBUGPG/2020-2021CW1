# Learning Journal 

## Stuff I have learned 

29/09/2020 - To make a header you just need to add # at the top and right that you want to have on the header.

12/10/2020 - I started making a behaviour script but I was putting variables which made the script not work if I'm making a behaviour script don't use variables it doesn't work.

12/10/2020 - I made a script that was cold script1 then I change the name and forgot to changer the name inside of the script so I was getting errors. ***Remember*** if you **change something** from the top of the script like a name you need to make sure the **change name** was changed down the script as well or it will not work.

14/10/2020 - I tried using raycast to detect the player but it was not working. You need a `collider for raycast` to work.

14/10/2020 - I tried to cast the raycast from the player to a lamp and it was working but you can't add more lights to the script so I made the light to send a raycast to the player. Make sure you cast the raycast from the player and not from the light sources.

15/10/2020 - I made a script which was using tags to comper but it didn't work because I forgot to tag the object. ***Don't forget*** to add a `tag` or a `layer mask` to you object if your script is looking for them.

15/10/2020 - I forgot that I deactivated a game object that had the script for detection and it was not working because it was deactivated. ***Don't forget*** to tick the checkbox on the top right side of your inspector so your script works.

17/10/2020 - I had a problem with a big portion of my script so I used /* and */ to stop it from running so I can try something different. If you want to make a big section of your scrip not to run you can use `/*` from the starting point and `*/` at the end and anything in between we not run by the script. 

19/10/2020 - My game was running in two different speeds when I build it so I used Time.deltaTime to make it go with the same speed. ```Time.deltaTime``` Is used to make the game run with the same speed on any devices.

25/10/2020 - My raycast was making it hard to measure distances so I started using a line cast because it is easier to set the distance. Line cast is a command that makes a straight line from one point to another it can be used as a tripwire or a laser sensor.  

13/11/2020 - I had a problem with one of my code so I had to turn it off and then made a script that tunes the scrip back on when the game starts playing. ```this.GetComponent<CantSeeMe>().enabled = true;``` This line of code can enable or disable scrips. 

16/11/2020 - In my script, it had to go for so much object with different values I used foreach (sun s in suns) this command made my game from getting different values and it was only looking for the one I need it. ```foreach (sun s in suns)``` This line of code is used to go through several game object and checks each one of them. 

23/11/2020 - I couldn't tell where were my raycast looking at so I used DrawRay to draw red lin in the direction they are looking at. ```DrawRay``` Is better then DrawLine when looking for where does the Raycast hit.

29/11/2020 - Some of my raycast stop working and I didn't know why the reason for that is that raycast can't go through colliders even when the renderer is tick off. Raycast can't go through any colliders.

08/12/2020 - I had to turn off a lot of my object and then turned them on so I used .enable to turn them on and off. You can reference a game object with a public value and the enable or disable it with. ```.enable = true/false```
