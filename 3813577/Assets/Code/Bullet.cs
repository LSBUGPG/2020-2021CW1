using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb2d;
    public int damage;
    public GameObject BulletEx;

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.right * speed;
    }
	void OnTriggerEnter2D(Collider2D hitinfo)
	{
        Enemy1 enemy = hitinfo.GetComponent<Enemy1>();
        if (enemy != null)
		{
            enemy.TakeDamge(damage);
            enemy.Feedback();
		}
        PlayerMechanics player = hitinfo.GetComponent<PlayerMechanics>();
        if (player != null)
		{
            player.TakeDamge(damage);
		}
        Instantiate(BulletEx, transform.position, quaternion.identity);
        Destroy(gameObject);
	}
}
