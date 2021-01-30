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
