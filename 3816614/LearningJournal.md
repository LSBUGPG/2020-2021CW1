# Connor Howard's Learning Journal

## 13/10/20
I started off by programming the enemy spawner script. This was achieved by roatating an object around a centre point and then having a two integers be incrimented. once one integer hits a value of 60 to count for a second it would randomly set the value of another integer and then reset the value of the first to 0 to repeat this process once every second. I then have it set so that if the second integer that is being incremented becomes greater than or equal to the value of the randomly set variable it would spawn an enemy and then slightly increase the speed of the objects rotation to help keep the timing and location of spawning random.
![a](https://user-images.githubusercontent.com/72077595/105555741-f4e60d80-5d01-11eb-8b09-24949bce9ba6.PNG)

## 20/10/20
Once the spawner script was in place I then moved on to creating the enemy movement script. The method I used for this was by using Ray casting while having the enemy look in the direction of the player, then applied force to move the enemy around. I ran into an issue with getting the enemy to contantly look at the player and originally had calculated the distance between the enemy and the player object, then tried to use this value as the axis values for a vector3 variable. I got around this by instead having the enemy locate the player object through "player = GameObject.Find("Player");" inside the start method. I then would use the raycast to hit the player and use "rb.AddForce(new Vector3(transform.forward.x * speed * Time.deltaTime, 0, transform.forward.z * speed * Time.deltaTime), ForceMode.Impulse);".
![b](https://user-images.githubusercontent.com/72077595/105568356-9a17da80-5d30-11eb-9b62-6df5b1684239.PNG)

## 27/10/20 | 10/11/20 | 17/11/20
I started working on the Player movement script and found myself running into several issues. I had my player movement detect input from the keyboard and then manipulate the velocity of the player object directly. While this worked fine for mevement it posed a problem when it came to collision, The player would be able to clip through solid collisions if the velocity hit high enough values, I could of course put a cap on the volicity but instead I opted to change the method entirely. I now use force applied to the object just like the enemy to move the player, I found this not to be as smooth as adjusting velocity but it sorted all of the collision issues I faced.
![c](https://user-images.githubusercontent.com/72077595/105568815-414a4100-5d34-11eb-8759-7a2344f19e3c.PNG)

## 16/10/20 | 03/11/20 | 4/11/20
I spent some days researching how to program shaders from scratch so I could make my own effects for my 3D game as well as future projects. It was a real challenge because the programming language used is not C# but rather "ShaderLab". Took a few days of research and following along but managed to get a script that would make the material fully transparent and then create a variable that would allow the value of transparency be adjusted through C# scripts.

![d](https://user-images.githubusercontent.com/72077595/105570255-0ea64580-5d40-11eb-85c5-8516bb679a1c.PNG)

## 13/11/20
I further developed a script I had for my 3D game, I needed to have the enemies shrink when they are caught within a suction zone, I ran into some issues with having the enemies shrink at an even pace and with the colliders messing with the collider of the player it is being sucked into. I fixed this by disabling the collider and using Vector3.Lerp to shrink the object while then disabling each mesh renderer within the object when it shrunk to a set value, this helped give the impression of it dissapearing into the source of suction.
![e](https://user-images.githubusercontent.com/72077595/105570424-537eac00-5d41-11eb-8405-7a258ce02701.PNG)

## 19/11/20 | 28/11/20
I spent time researching how to gain the relative direction of Vector3 from one script and use it to direct force on to an enemy object in another script. I did this by referencing the Vector3 "LaunchDirection" variable in another script that sets it's value to be equal to the players transform.forward values within the start method. I then would add force to the enemy when they are pushed back using the new variable values as a source of direction within a ray cast that checks for walls. The only issue I had with this was using velocity at first instead of add force which again possed problems with the collisions.
![f](https://user-images.githubusercontent.com/72077595/105571646-acead900-5d49-11eb-96d4-71842726211e.PNG)

