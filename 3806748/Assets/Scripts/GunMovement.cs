using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public float MaxMoveUp = 50;
    public float MaxMoveDown = 10;
    public float RotateRate = 10;

    public KeyCode MoveUpKey = KeyCode.UpArrow;
    public KeyCode MoveDownKey = KeyCode.DownArrow;


    private void Update()
    {
        GetUserInput();
    }

    private void GetUserInput()
    {
        if (Input.GetKey(MoveUpKey))
        {
            if (transform.rotation.eulerAngles.x < MaxMoveUp)
            {
                transform.Rotate(new Vector3(RotateRate * Time.deltaTime, 0, 0));
            }
        }
        else if(Input.GetKey(MoveDownKey))
        {
            if (transform.rotation.eulerAngles.x > MaxMoveDown)
            {
                transform.Rotate(new Vector3(-RotateRate * Time.deltaTime, 0, 0));
            }
        }
    }
}
