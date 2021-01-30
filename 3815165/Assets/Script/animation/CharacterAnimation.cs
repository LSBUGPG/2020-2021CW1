using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    Animator myAnimator;
    private Animator anim;
    private Rigidbody rb;
    public float JumpSpeed = 5f;

    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
        myAnimator = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            myAnimator.SetBool("istheplayermoving", true);
        }

        if (!Input.GetKey("w"))
        {
            myAnimator.SetBool("istheplayermoving", false);
        }

        if (Input.GetKey("s"))
        {
            myAnimator.SetBool("istheplayermovingback", true);
        }

        if (!Input.GetKey("s"))
        {
            myAnimator.SetBool("istheplayermovingback", false);
        }

        if (Input.GetKey("a"))
        {
            myAnimator.SetBool("istheplayermovingleft", true);
        }

        if (!Input.GetKey("a"))
        {
            myAnimator.SetBool("istheplayermovingleft", false);
        }

        if (Input.GetKey("d"))
        {
            myAnimator.SetBool("istheplayermovingright", true);
        }

        if (!Input.GetKey("d"))
        {
            myAnimator.SetBool("istheplayermovingright", false);
        }


        if (Input.GetKey("space"))
        {
            myAnimator.SetBool("istheplayerjumping", true);
        }

        if (!Input.GetKey("space"))
        {
            myAnimator.SetBool("istheplayerjumping", false);
        }

        if (Input.GetAxis("Jump") != 0 && grounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpSpeed, rb.velocity.z);
            anim.SetTrigger("space");
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            myAnimator.SetBool("isflying", true);
        }

        if (!Input.GetKey(KeyCode.Mouse0))
        {
            myAnimator.SetBool("isflying", false);

        }
    }
}   
