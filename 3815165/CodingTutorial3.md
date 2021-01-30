# Shooting Enemy AI
This shows you how to create an enemy AI in unity which follow the player, retreat when the player player come near it and most importantly shoot projectile at the player. 
## 1. Making a new scene 
- Start this tutorial by creating a new scene in unity called 'Shooting Enemy AI' 
- Creating 2 square sprites, one is for the player and other is for the enemy. you do this by clicking on the Assets, create, sprite.
- After this change the colour of the player's sprite to blue and change the colour of the enemy's sprite to red. you do this by clicking on the sprite, then go to colour under the sprite render.
- Go to the player and under the Inspector window change the player's tag to 'Player' 
- Make a red circle in photoshop and import it into Unity. This circle will be used as the projectile of the enemy later on.
- Then make a folder called 'Prefabs' by right clicking in the Project window, then create, folder. After this put the red circle(the projectile), player and enemy sprites inside the folder.
- After that create a new folder called 'Scripts' by right clicking in the Project window, create, folder. Inside this folder create a script called 'Enemy'. 

## 2.The coding part
### Creating Variables
- In the script under the Public Class, create a public float called 'speed', we will be using this to adjust the speed of the enemy. After this, we will be creating a public float called 'StoppingDistance' this is used to make the enemy stay away from the player, which mean the higher this variable, the longer the distance between the enemy and the player will be. Then make another public float variable called 'retreatDistant' this is used to tell the enemy when they should move away from the player. Then create a public transform variable called 'player'. After this create a private float called 'TimeBtwShots' and then create a public float called 'startTimeBtwShots' these 2 variables are used to control how long does it take for the enemy to spawn a projectile. After this, make a public GameObject called 'projectile' which is used to store the enemy's projectile. the first part of the Script should look like this if it is done properly.

using System.Collections;

using System.Collections.Generic;

using System.Security.Cryptography;

using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject Projectile;
    private Transform player;
    
 ### Starting Function
- In the starting function set the 'player' variable equal to the position of the game object that has the tag called 'Player' by using this line of code "player = GameObject.FindGameObjectWithTag("Player").transform;". 

- Then set the 'timeBtwShots' equal to the 'startTimeBtwShots' this is a crucial part of the code, if you don't put this line of code here the enemy will shoot out the projectile in the total of 60 times per second. If this is done correctly, it should look like this:
 
   void Start()
    {
    
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }
 
 ### Update Function
 #### If statement
 - Inside the update function, create an if Statement and we will be using this if statement to check the distance between the player and the enemy. wee need to used this code "Vector2.Distance(transform.position, player.position)" to check the distance of the enemy and the player. also if the distance between these objects is larger than the number of the 'stoppingDistance' variable then we want the enemy to move straight toward the player. Furthermore, to make the enemy move to the player, we need to set the enemy's current position equal to the player's position. After this set, the position of the enemy, the player, the speed of the enemy inside the brackets and times everything with Time.deltaTime to make sure that everything runs smoothly "transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);".
 
 #### Else if statement
 - Inside the update function we need to use the else if statement to check if the enemy is too closed to the player, the enemy will stop moving toward the player. To do this we will use this line of code "(Vector2.Distance(transform.position, player.position) < stoppingDistance) " to check for the 'stoppingDistance' to see if the distance between the 2 characters is smaller than the value of 'stoppingDistance', if it is smaller then the enemy will stop moving. Also, we need to continue the code to make sure that the enemy doesn't get too close to the player by adding this line of code "&& Vector2.Distance(transform.position, player.position) > retreatDistance)". We want the enemy to stop moving when it is near to the player by setting his position to the same position again and again by using "transform.position = this.transform.position;". 
 
 #### Else if Statement
 - This is else if statement is used to check if the distance separating the player and the enemy than the value of the 'retreatDistance' variable. If it is then we need to use the "transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);"  this means that when the enemy is too closed to the player, it will simply back away from the player.
 
 #### If Statement
 - This if statement is used to check if the 'timeBtwShots' is less than or equal to 0. If it is then the enemy will spawn a projectile. If it isn't we will decrease the number by setting the 'timeBtwShots' is less than or equal Time.deltaTime. To do this, we need to use Instantiate to spawn the projectile at the enemy's position with no rotation "Instantiate(Projectile, transform.position, Quaternion.identity);". then underneath this code, set 'timeBtwShots' equal to 'startTimeBtwShots' to make sure that the enemy doesn't spawn projectile 60 times per second. Everything in the update function should look like this if you have done it right:
 
 void Update()
    {
    
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){

            transform.position = this.transform.position;

        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0){

            Instantiate(Projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        } else {

            timeBtwShots -= Time.deltaTime;
        }

    }
 
 }
 
 ## 3. Coding part 2 (for the projectile)
 Create another Script called 'Projectile' in the Scripts folder
 ### creating the variables
 - First, we need to create a public float called 'speed' to control the speed of the projectile. Also, we will create a private transform called 'Player' and a private vector2 called 'target'. if this is done correctly, it should look like this:
 
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;

### Start Function
- In the start function we need to set the 'player' variable equal to the game object in the scene that has a tag named 'Player' and the transform of that object it should look like this "player = GameObject.FindGameObjectWithTag("Player").transform;".
- Set the target variable equal to the players X and Y coordinates, this means that the variable is equal to the position of the player when the enemy spawn a projectile.  

 void Start()
    {
    
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

### Update Function 
- In the update function, we want to make the projectile move straight toward the player's fixed position. The projectile will quickly move toward the player's position doesn't matter if the player is still in the same position or not.
- Next up, we will check if the projectile has reached the fixed position  by using a function called 'DestroyProjectile'

#### OnTriggerEnter2D Function that has a Collider 2D called 'Other'
- We use this function to make sure that the projectile destroys itself when it makes contact with the player. We do this by using an if statement to say that if the projectile hit the object with tag 'Player', it will active the 'DestroyProjectile' function. which destroy the projectile.

void OntriggerEnter2D(Collider2D other)
{

        if (other.CompareTag("Player")){
            DestroyProjectile();
        }
    }

#### DestroyProjectile Function
- Inside this function, we need to write "DestroygameObject" to destroy the projectile when it reaches its final postion.

void DestroyProjectile(){

        Destroy(gameObject);
    }
}

## 4. Combining everything 
- Add the 'Projectile' script to the projectile prefab(red circle) by dragging it in the add components section of the projectile. Also, change the speed of the projectile to 10 under the Inspector window.
- Add the 'Enemy' script to the enemy by dragging the script in the add component section of the enemy
- Change the speed of the enemy to 4, the stopping distance to 7, the retreat distance to 5, the start time Btw shots to 2 under the Inspector window. Also, drag the project tile prefab to the empty slot called 'Projectile'.
- Tag the character with the 'Player' tag under the Inspector window.
- Test out the game by moving the character around and see if the enemy shoots the projectile at the player or not. Also to see if the enemy move away from the player if he/she is near it or not. 
