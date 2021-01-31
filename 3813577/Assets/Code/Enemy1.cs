using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
	public int health;
	public GameObject Dead;
	public GameObject Spawn;
	public float Counter;
	public SpriteRenderer EnemyColor;
	public void Update()
	{
		Counter = Counter + Time.deltaTime;
		if(Counter > 0.2)
		{
			EnemyColor.color = Color.white;
		}
	}

	public void TakeDamge(int damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Death();
			Destroy(gameObject);
		}
	}
	public void Death()
	{
		Instantiate(Dead, Spawn.transform.position, Quaternion.identity);
	}
	public void Feedback()
	{
		EnemyColor.color = Color.red;
		Counter = 0;
	}
}