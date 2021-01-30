using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = -20f;
    float currentTime = 0;
    float startTime = 2f;
    bool startTimer = false;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            float s = (currentTime / startTime);
            if (s < 0)
            {
                Player.GetComponent<Bandit>().ReduceHealth();
                Destroy(gameObject);
            }
        }
        transform.Translate(speed*Time.deltaTime,0,0);
        currentTime -= 1 * Time.deltaTime;
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            startTimer = true;
            Player = collision.gameObject;
        }
    }

}
