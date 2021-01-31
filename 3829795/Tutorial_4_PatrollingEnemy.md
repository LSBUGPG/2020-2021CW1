# Setting Up Enemy Patrols

This tutorial will teach you how to set up enemy waypoints with the enemy being able to patrol between them.

This tutorial requires you to have a 3D open scene.


## 1. Setting up your scene

With your scene open you will need to set up a floor, AI and the waypoints. 
We will start by setting up the floor, we will be using a plane for the floor which can be found by right clicking in the Hierarchy tab, going to “3D objects” and clicking on “plane”.

We will be using the same method to make our enemies body and the waypoints the enemy will follow. The enemy will be a 3D Cube and our way points will be 3D Spheres.
Create two separate spheres and put them at either ends of your plane while keeping your AI in the middle.


## 2. Setting up your code


Now on your enemy in your `inspector tab` you will go to `Add Component` and write in “patrol”, this will prompt Unity to allow you to create your own script.

Now you will need a few public and private variables that will be referenced throughout your code.
To create variables you will need to write it above the `void Start ()` function.

Now we will need the location of all the waypoints, so our AI knows where to go and put them all in a list so are AI goes to each one in a certain order. We also need to find a way to tell the AI how fast to travel to those way points. As a Final precaution we will also be judging how much distance is between the AI and the waypoint the AI is currently traveling too. To do each function, the below code will be needed, respectively.

```
Public Transform[] waypoints;
Private int waypointIndex;
Public int speed;
Private float dist;
```

From there we need to have functions that activate once the game begins, to do this, we will write the next segment in the `void Start ()` function between the curly brackets.
We want to set up a index for our waypoints so we can set them all in a list as well as make our AI look at the waypoint they will be heading too.
The syntax looks like this.
```
waypointIndex = 0;
transform.LookAt(waypoints[waypointIndex].position)
```

We will skip the `void update ()` function as we will need to create a few of our own functions that will be referenced there. We will need to create a patrol and an Increase Index function.

Our Patrol function will tell our AI to move forward at a speed that is relative to our computers processing power, so the speed does not change when the game is run on a faster or slower computer. 
Our Increase Index function will tell our AI to go to the next waypoint in the index once it reaches the one its currently moving toward, it will also reset the order of the index once it reached the last waypoint in the list.
Each function is separate and is written below the second curly bracket of void Update ()` and it written like so.

```
void Patrol()
{
	Transform.Translate(Vector3.forward * speed * Time.deltaTime);
}

void IncreaseIndex()
{
	waypointIndex++;
	if(waypointIndex >= waypoints.Length)
	{
		waypointIndex = 0;
	}
	transform.LookAt(waypoints[waypointsIndex].position);
}
```

Now we need to go to void Update ()` and reference the new functions we’ve created and to finish our script.

In update we will need to create the function of when our AI gets within a certain range of the waypoint it is traveling to, it will then go to the next waypoint in the index and keep going until it reaches the final waypoint and then go back to the first. 
We will also need the AI to continuously move toward these waypoints which means we need to reference the patrol script in update without any prior conditions needing to have been met.
The Syntax is written below.

```
Dist = Vector3.Distance(transform.position, waypoints[waypointsIndex].position);
If(dist < 1f)
{
	IncreaseIndex();
}
Patrol();
```


## 3. Attach everything in the Inspector Tab

In the AI’s Inspector tab, you will see `Waypoints` and `size`, you will want to set the size to 2 as that is how many waypoints you currently have in your scene. This will create two extra boxes called “Element 0” and “Element 1” as Unity counts from zero first. 
Drag each waypoint to the boxes depends on the order you want your AI to travel in.

Once you play the scene providing there is no errors, the AI should move between each script, you can also change the speed in the Inspector tab underneath where you assigned the waypoints.

Thanks for reading!
