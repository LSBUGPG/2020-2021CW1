using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
    public float Vel;
    public float TurnRate;

    private bool Active = true;

    private float FurthestMoveLeft;
    private float FurthestMoveRight;
    private float FurthestMoveUp;
    private float FurthestMoveBack;

    private bool FloorFound = false;
    private bool NewWall = true;

    // Update is called once per frame
    void Update()
    {
        //We don't want to be checking movement if no floor has been found yet
        if (FloorFound)
        {
            MoveLogic();
        }
    }

    private void CheckBoundaries()
    {
        /**|| Each of these nested if statements check if the object has reached or gone past a boundary
              If the object has, the program checks if it is rotated enough to not fall off. 
              If it is rotated enough then nothing happens, however if it is not then this function will be called again later ||**/
        if (transform.position.z >= (FurthestMoveUp - transform.localScale.z))
        {
            if (transform.eulerAngles[1] < 90 && transform.eulerAngles[1] > -90)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
        }

        if (transform.position.x >= (FurthestMoveRight - transform.localScale.x))
        {
            if (transform.eulerAngles[1] < 180 && transform.eulerAngles[1] > 0)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
        }

        if (transform.position.z <= (FurthestMoveBack + transform.localScale.z))
        {
            if (transform.eulerAngles[1] < 270 && transform.eulerAngles[1] > 90)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
        }

        if (transform.position.x <= (FurthestMoveLeft + transform.localScale.x))
        {
            if (transform.eulerAngles[1] > 175)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
        }
    }
    private void MoveLogic()
    {
        CheckBoundaries();

        if(transform.eulerAngles[1] >= 355)
        {
            // This is here to reset rotation, avoids spinning infinitely sometimes
            transform.rotation = new Quaternion(0, 1, 0, 0);
        }

        if (Active)
        {
            //Move in the forward direction
            MoveInDirection(Vector3.forward);

            //NewWall means has the object hit a new side of the floor? if so the turn direction will be randomised
            NewWall = true;
        }
        else
        {
            if (NewWall)
            {
                //50% chance to change direction
                float TempNewDirection = Random.Range(-1, 3);

                if(TempNewDirection > 0)
                {
                    //Keep same turn direction
                    TempNewDirection = 1;
                }
                else
                {
                    //Reverse turning
                    TempNewDirection = -1;
                }

                //Apply changes of direction and stop changing the direction
                TurnRate *= TempNewDirection;
                NewWall = false;
            }

            RotateObject(new Vector3(0, TurnRate, 0)); 
            //Add * Time.deltaTime after TurnRate if you want the object to not turn instantly, although this can be buggy for certain speeds.

        }
    }

    private void MoveLogicInit(Transform FloorObj)
    {
        // Calculate the boundaries of the floor. We do not bother with the Y axis as it is irrelevant in this tutorial
        //We +/- half the size of the floor as the XYZ positions are determined from the centre of the object, not the corner
        FurthestMoveUp = FloorObj.position.x + (FloorObj.localScale[0] / 2);
        FurthestMoveBack = FloorObj.position.x - (FloorObj.localScale[0] / 2);

        FurthestMoveRight = FloorObj.position.z + (FloorObj.localScale[2] / 2);
        FurthestMoveLeft = FloorObj.position.z - (FloorObj.localScale[2] / 2);

        //Activates the movement code
        FloorFound = true;
    }

    private void MoveInDirection(Vector3 Direction)
    {
        // transform.Translate = Move in a Direction
        // Direction = Forward, time.deltaTime so that movement is not affected by frame rate  
        transform.Translate(Direction * Vel * Time.deltaTime);
    }

    private void RotateObject(Vector3 Direction)
    {
        // This rotation is in 2D, so only the Y coord (Direction[1]) needs to be changed
        transform.Rotate(new Vector3(0, Direction[1], 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            // Assign this object as the current edge detection object, if it is marked as "floor" ie: a pathing object
            MoveLogicInit(collision.transform);
        }
    }
}
