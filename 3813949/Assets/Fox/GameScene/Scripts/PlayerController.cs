using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D myRB;
    public float maxSpeed;
    bool facingRight = true;
    SpriteRenderer myRenderer;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if(move > 0 && !facingRight)
        {
            Flip();

        }
        else if(move < 0 && facingRight)
        {
            Flip();
        }
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        myAnim.SetFloat("MoveSpeed", Mathf.Abs(move));
    }
    void Flip()
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX;
    }
}
