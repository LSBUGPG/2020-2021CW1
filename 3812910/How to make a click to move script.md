# How to make a click to move script

## Setup

First, start unity then you need a player to get a player right click on the ``sample scene`` 
then click on 3d object and select capsule this is your player. To ``tag`` him as the player you 
need to click on the capsule then go to inspector, it should be on the left of unity near the 
top you should is a rectangle that says untagged click on it and selects the tag ``player`` after 
that you can cheng the name of the capsule player. Then go to the inspector agine and go to 
the bottom of inspector where it says ``Add Component``, then click on the search bar and write 
``Nav Mesh Agent`` then click on it and add it to your player. Second you will need a ground a 
place where you can walk so got to the hierarchy on the left side of unity and right-click to 
open the menu then go to 3D objects and select plane that will be your ground. Then click on the
``navigation`` that is located next to the inspector on the top right of your unity. After you have 
clicked it go to ``object`` that is near to the top of navigation the click on your ground object 
and then click on the ``navigation area`` under the ``plane (Mesh renderer)`` and select walkable.
Then next to object there is something called ``bake`` click on it and near the bottom, you will
see a button that says bake on it click it. Then go to the inspector and click on the layer box 
on the right side of inspector then click on ``add layer`` and write ``Ground``.

## Coding 

Click on the player and go to inspector after going to the bottom, of inspector and select add 
component in the search bar wright 'move' the click new script and press enter. Then write click
on the very top where it says ``using UnityEngine;`` and write below it ``using UnityEngine.AI;``

Select the green text above ``void start`` and delete it than write in it places this.

```
   public LayerMask whatCanBeClickedon;

   private NavMeshAgent myAgent;
```
This is just references for your script.

The write this inside of the ``void start``

```
 myAgent = GetComponent<NavMeshAgent>();
```
This is just telling the script what to do at the start.

Then write this inside of your ``void update``.

```
if (Input.GetMouseButtonDown (0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast (myRay, out hitInfo, 100, whatCanBeClickedon))
            {
                myAgent.SetDestination (hitInfo.point);
            }
        }
```
This is telling your unity when you left-click it will send a ray that acts like a point
that your player will go to.

Save your scrip and go back to unity after your back go to your player go to the inspector 
and click on the move script there should be an option that says ``whatCanBeClickedon``
click on the box and select your ``Ground`` that you made then play the game and it should work.
