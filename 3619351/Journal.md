# 5/10/2020
I have decided to use one of my game that I was currently making as part of the submission of this coursework.
But due to massive amount of issues such as scripts being broken from updating Unity (And reformatting my PC at one point).
I had to completely restart almost the entire thing from scratch.

Issues involved:
Player's recalling the projectile script was completely broken. The projectile would stop in position and won't return to its original position it was set on after pressing the recall button.
Player won't move.

One of my original player shooting script that I was going to use for behaviour but completely broke:

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    [Header ("Basic Settings")]
    public bool isShot = false;
    public GameObject player;
    public float shootSpeed;
    private Rigidbody2D body;
    private Transform original;
    private bool callBack = false;
    public float speedCallBack = 1f;
    float value;
    float constantSpeed;
 
 
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 faceDirection = new Vector2
        (
                mousePosition.x - transform.position.x,
                mousePosition.y - transform.position.y
        );

        transform.parent = null;
        transform.right = faceDirection;
        body.simulated = true;
        body.bodyType = RigidbodyType2D.Dynamic;
        body.AddForce(faceDirection.normalized * shootSpeed);
        Invoke("SetTrue", 0.2f);
    }

    void SetTrue()
    {
        isShot = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isShot)
        {
            callBack = true;
            value = 0f;
            body.bodyType = RigidbodyType2D.Kinematic;
            body.simulated = false;
            transform.parent = player.transform;

            // If you want constant speed, never faster, never slower, you can do:
            // rigidbody2D.velocity = rigidbody2D.velocity.normalized * shootSpeed;
            
            // If you want to limit the speed to some upper limit you can do:
            // rigidbody2D.velocity = Vector2.ClampMangnitude(rigidbody2D.velocity, maxSpeed);

            //transform.position = original.position;
            isShot = false;
        }
    }

    private void Update()
    {
        if (callBack)
        {
            value += Time.deltaTime * speedCallBack;
            transform.position = Vector3.Lerp(transform.position, original.position, value);
            float distance = (original.position - transform.position).magnitude;
            if (distance <= 0.1f)
            {
                transform.position = original.position;
                callBack = false;
            }
        }
        constantSpeed = 30f;

        Vector2 unit = GetComponent<Rigidbody2D>().velocity.normalized;
        GetComponent<Rigidbody2D>().velocity = unit * constantSpeed;
    }
}


# 14/11/2020
I spent most of the time trying to resolve the issue, taking a long break from programming due to being unable to fix the game that I wanted to make.
I began making a new Unity game from the beginning and slowly build my way up to where the AI will shoot at the player and the player can freely shoot around at a 360 degree (which wasn't easy for me to do).

First of all, I created the player and the player's movement script.
I have rewritten my script at least a few times to get the player moving.

Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start ()
    {   
    body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
    body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

This script seems to have worked at least for me.

# 15/11/2020
I have started making the AI for my game again, but I still need to make the AI move at certain points but doing so may cost me a lot of time so I avoided this process for the meanwhile and would do it in my spare time as a hobby instead.
What I really wanted to learn was to make an AI move smartly on its own without putting certain points of interest where it will move to the points I put into.

For example, the AI from Fallout 4 or the AI from many FPS games that finds the nearest cover or moves randomly on their own.
So instead of making such a complicated task, I just made the enemy as a stationary turret that shoots at the player's position.

# 28/11/2020
It took me a long time to figure out how to make the enemy AI shoot at the player.
This includes separating two scripts from the enemy.

One script is the EnemyROF for the enemy and the other is the enemyProjectile for the enemy's projectile.

First, I made the fire rate of the enemy based on how many shots will the enemy make per second.
Second, I made the projectile fire towards the player.

# 30/11/2020
I began debugging my game for a little bit to see if there were any problems before I began making the Player shooting script.

I have tried re-using the script and re-editing the script I have from the previous player shooting script, but it remained completely broken.
So I decided to do the same shooting method that I have done for the AI except I had to rewrite it differently for the player.

# 3/12/2020
I didn't expect that I would have a lot of issues making the player shooting script for a 2D game.

Scripts that I have tried:


A lot of issues happened when I was making the player shooting script.

Issues I have encountered:
1.) Player's projectile won't instantiate.
2.) Player won't shoot at all.

I have manage to fix the issue on the 6th of December, 2020 by renaming some parts of the player projectile's script.

I think the problem was that I had some scripts set to public and I have called them to my current script or I might have written the script as a GameObject's name.
Either way, renaming it fixed the shooting issue that took me quite long to do. I don't really know what the real issue was.