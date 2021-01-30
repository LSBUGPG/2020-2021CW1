# How to make the enemy shoot projectile at the player

Important Note: This tutorial requires much more focus on the steps for it to work.

Now that you have the `Enemy Projectile` prefab, create a new script.
Rename this script as `Projectile` or whichever you want to name it.
Leave the script for now and lets move to the most important part.

Important steps:
1.) Click on the `Enemy Projectile` prefab in the `Assets` > `Art` folder.
2.) Check the `Inspector` tab of the `Enemy Projectile` and make sure it is a 2D Collider and a 2D Rigidbody. This is very important. Remove the Collider and Rigidbody if it is NOT a 2D.

# Create the Projectile script for the enemy.

Rename the script to `Projectile`.

# Writing the script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour {

	public float projectileSpeed;
	Rigidbody2D rb;

	Player target;
	Vector2 projectileDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Player>();
		projectileDirection = (target.transform.position - transform.position).normalized * projectileSpeed;
		rb.velocity = new Vector2 (projectileDirection.x, projectileDirection.y);
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.name.Equals ("Player"))
		{
			Debug.Log("Hit!");
			Destroy (gameObject);
		}
	}
}

# Placing the script

Click and drag `Projectile` script to the `EnemyProjectile` prefab's `Inspector` tab.
In the `Inspector` tab of the `EnemyProjectile`, there should also be a Projectile Speed, set the speed to whatever value you wish for it. This is important if you want the Projectile to move towards the player and for it to work.