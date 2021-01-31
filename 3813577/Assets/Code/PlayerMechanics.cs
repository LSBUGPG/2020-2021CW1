using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bullet;
    public int health;
    // Update is called once per frame
    void Update()
    {
    if(Input.GetButtonDown("Fire1"))
		{
            Shoot();
		}
    }
    void Shoot()
	{
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
	}
	public void TakeDamge(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
