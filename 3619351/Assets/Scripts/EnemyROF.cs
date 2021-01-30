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
		fireRate = 0.5f;
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