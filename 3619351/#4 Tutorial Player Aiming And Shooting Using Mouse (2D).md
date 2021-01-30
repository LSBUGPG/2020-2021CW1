# Creating the Player Projectile.

Just like the previous tutorial (2nd Tutorial), create a `3D Object` > `Sphere`
Rename this `Sphere` to `PlayerProjectile`
Left click and drag the `PlayerProjectile` from the `Scene` tab just under the `Hierarchy` to the `Assets` > `Art` to create the Prefab for the projectile.

Now, we are going to make the bullet point (Where the bullet will fire at).
Right click in the `Scene` tab then `Create Empty`.
Rename this empty `GameObject` to `ShootPoint` or whichever you prefer to call it.
Left click and drag the `ShootPoint` from the `Scene` tab to the `Player` GameObject in the same tab.
This will create the `Player` as the `Parent` of the `ShootPoint` while the `ShootPoint` is the child of the `Player`.

Make sure the Transform `Position` of the `ShootPoint` in the `Inspector` tab is X = 0, Y = 0, Z = 0.
This will centre the shoot point in the middle of the player. You can freely choose whichever position you want to have the shoot point at.

Now create the Script for the Projectile.

# Creating the Player shooting script.

Just like how you make the scripts from previous tutorials, make a new script and rename this to `playerProjectile`.

# Writing the Player shooting script.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectile : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50f;

    Vector2 lookDirection;
    float lookAngle;

    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = firePoint.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}

# Final Steps

1.) Drag the script to the `Player`, you should have two scripts for the `Player` (The two scripts are: `Player` and `playerProjectile`, in other words, Player movement script + Player shooting script)
2.) In the `Inspector` tab of the `Player` GameObject in the `Scene`, you will notice there is the `Player Projectile` script. Under this script, simply drag the `Player Projectile` to the `Bullet` as the GameObject.
3.) Next, the `Fire Point`; just drag the `ShootPoint` to the `Fire Point` as the GameObject.
4.) Test and see if the script works by using the left mouse button to fire.