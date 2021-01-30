using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movespeed;
    public float rotspeed;
    public float rotX;
    public float rotY;
    public float rotZ;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * movespeed);
        rotY += Input.GetAxis("Horizontal") * Time.deltaTime * rotspeed;

        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);

    }

}
