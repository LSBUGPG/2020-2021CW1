using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    public Rigidbody2D rb2d;
    float MoveX;
    public Animator Animo;
    public GameObject FirePoint;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxis("Horizontal");
        transform.Translate (new Vector3 (MoveX, 0, 0) * Time.deltaTime * MovementSpeed);
        Animo.SetFloat("Speed", Mathf.Abs(MoveX));
        if (MoveX > 0 || MoveX < 0)
        {
            int direction;
            if (MoveX > 0)
            {
                direction = 1;
                FirePoint.GetComponent<FirePoint>().NoRotate();
            }
            else
            {
                direction = -1;
                FirePoint.GetComponent<FirePoint>().Rotate();
            }
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y);

        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb2d.velocity.y) < 0.01f)
		{
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Animo.SetBool("Jump", true);
		}
		else
		{
            Animo.SetBool("Jump", false);
		}
    }
}