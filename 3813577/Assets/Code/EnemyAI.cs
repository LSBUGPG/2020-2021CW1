using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public Transform enemyPosition;
    float Distance;
    public float MovementSpeed;
    public Transform InitialTransform;

	private void Awake()
	{
        InitialTransform = GetComponent<Transform>();
	}
	// Start is called before the first frame update
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyPosition = GetComponent<Transform>();
    }

	private void FixedUpdate()
	{
        Distance = enemyPosition.position.x - player.position.x;
    }
	// Update is called once per frame
	void Update()
    {
        if (Distance  < 20 && enemyPosition.position.x > player.position.x && Distance > 3)
		{
        transform.Translate(new Vector2(-1, 0) * Time.deltaTime * MovementSpeed);
        }
        if(Distance < -3 && enemyPosition.position.x < player.position.x && Distance > -20 )
		{
            transform.Translate(new Vector2(1, 0) * Time.deltaTime * MovementSpeed);
		}
    }
}
