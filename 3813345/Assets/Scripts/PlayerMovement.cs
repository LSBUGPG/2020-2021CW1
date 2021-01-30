using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Ground collision check variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;

    //Movement variables
    public CharacterController controller;
    public float speed = 12f;

    //Jump variables
    public float jumpHeight = 3f;

    //Gravity variables
    public float gravity = -9.81f;
    private Vector3 velocity;

    //Death and spawning variables
    public LayerMask deathMask;
    public float livesNumber = 3f;
    private bool isDead;
    public Transform spawn;
    public GameObject player;

    //Score
    public static int count;
    public Text coinCount;

    private void Start()
    {
        count = 0;
        SetCoinText();
    }


    // Update is called once per frame
    void Update()
    {
        //Death collition check
        isDead = Physics.CheckSphere(groundCheck.position, groundDistance, deathMask);
        if (isDead)
        {
            if (livesNumber > 0)
            {
                controller.enabled = false;
                player.transform.position = spawn.position;
                controller.enabled = true;
                livesNumber -= 1;
            }
            else
            {
                Debug.Log("Game Over");
            }
        }

        //Ground collision check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * speed * Time.deltaTime);

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        SetCoinText();
    }

    void SetCoinText()
    {
        coinCount.text = "Coins / " + count.ToString();
    }
}
