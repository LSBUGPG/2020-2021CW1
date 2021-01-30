using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw2 : MonoBehaviour
{
    Rigidbody myrb;
    public int result;
    bool landed = true;


    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(landed)
            {
                myrb.AddForce(Vector3.up  * 200);
                myrb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            }
        }
    }
}
