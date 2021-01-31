using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    //References Unity's character controller
    public CharacterController controller;

    //Sets movement speed
    public float speed = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Gets inputs for both X and Z axis and sets them on WASD or arrow keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.SimpleMove(move * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        //if enemy hits player then restart level
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
            
}
