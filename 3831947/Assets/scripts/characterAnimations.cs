using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimations : MonoBehaviour
{
    
    Animator myAnimator;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey ("s") || Input.GetKey ("a") || Input.GetKey ("d"))
        {
            myAnimator.SetBool("istheplayermoving", true);
        }
        else
        if (!Input.GetKey("w") || Input.GetKey ("s") || Input.GetKey ("a") || Input.GetKey ("d"))
        {
            myAnimator.SetBool("istheplayermoving", false);
        }
        

    }

   


}










