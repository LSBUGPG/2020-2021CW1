using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOver : MonoBehaviour
{

     public Animator fadeout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fadeout.SetTrigger("FadeOut");
        }
    }
}
