using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario64Lava : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D colObj)
    {
        if (colObj.gameObject.tag == ("lava"))
        {
            HealthSystem.health -= 1;
            Controller2D.rB.velocity = new Vector2(Controller2D.rB.velocity.x, 10);
        }
    }
}
