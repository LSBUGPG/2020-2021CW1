# Creating an Enemy

Important Note: This script won't shoot the Player, it is a rate of fire script for the enemy.

1.) Create a new 3D Object or 2D Object (If you have a sprite, but for this tutorial go for `3D Object Sphere`) in the `Hierarchy` tab, the same way you created the `Player`.
2.) Rename this object to `Enemy` so you know what it is.

# Create an Enemy Rate of Fire script

In the same script folder as the PlayerMovement, make a new script called `EnemyROF`.

# Writing the Enemy Rate of Fire script

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyROF : MonoBehaviour
{
    [SerializeField]
	GameObject projectile;
	float fireRate;
	float nextFire;

	// Use this for initialization
	void Start () {
		fireRate = 1.5f;
		nextFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		CheckIfTimeToFire ();
	}

	void CheckIfTimeToFire()
	{
		if (Time.time > nextFire)
		{
			Instantiate (projectile, transform.position, Quaternion.identity);
			nextFire = Time.time + fireRate;
		}
	}
}


# Placing the script to the Enemy and making the Enemy Projectile

Click and drag the `EnemyROF` script to the `Enemy` in its `Inspector` tab.
In the `Hierarchy`, select the `Enemy` and in the `Inspector` tab where the script is, there would be something called `Projectile` with `None (Game Object)` beneath the `Enemy ROF` script.
You will need to create a new `Game Object`.

For this tutorial, we will create a new `3D Object`.
Rename this Object to `EnemyProjectile`.

After that, follow these steps in order:
1.) Click on the `Assets` folder
2.) `Create` > `Folder` and rename this to `Art` (I use Art because this is where you should put your sprites at)
3.) On the `Hierarchy` tab, hold left click and drag the `EnemyProjectile` in the `Art` folder
4.) Once that is done, go to the `Scene` tab and `Delete` the `EnemyProjectile`
4.1) To delete the object from the scene, simply left click on the `EnemyProjectile` and press `Del` on your keyboard next to the `End` button (My keyboard says `Delete`).
5.) Now that you have your EnemyProjectile `Prefab`, left click on the `Enemy` object in the `Scene` or in the `Hierarchy` and simply hold left click and drag the EnemyProjectile prefab to the `None (Game Object)` of the script.

