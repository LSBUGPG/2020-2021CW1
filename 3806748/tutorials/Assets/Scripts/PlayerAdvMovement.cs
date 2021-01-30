using UnityEngine;

public class PlayerAdvMovement : MonoBehaviour
{
    public bool Active = true;

    //Note: this code is designed for a boat
    //If you want to make it realistic for a walker / humanoid you should speed up the turning and make the speed decay much faster

    //Generic Movement Values
    public float GenericSpeedMultiplier = 1; //Multiplier for most values. Recommended Values: Boat 5, Spaceship 20, Humanoid 50 
    public float GenericSpeedDecayMultiplier = 1; //Multiplier for speed decay
    public float Forward_Velocity_Increment = 1; //Rate of speed growth
    public float Back_Velocity_Increment = 0.5f; //Rate of speed growth
    public float R_Turn_Velocity_Increment = 0.25f; //Rate of speed growth
    public float L_Turn_Velocity_Increment = 0.25f; //Rate of speed growth
    public float Forward_Velocity_Max = 0; //Max forward speed
    public float Back_Velocity_Max = 0; //Max reverse speed
    public float R_Turn_Velocity_Max = 0; //Max R turn speed
    public float L_Turn_Velocity_Max = 0; //Max L turn speed

    private float Forward_Velocity_Current = 0; //Track speed
    private float Turn_Velocity_Current = 0; //Track speed

    private float Forward_Velocity_Max_Reversal; //Max speed when changing direction
    private float Back_Velocity_Max_Reversal; //Max speed when changing direction

    private bool Forward_Velocity_Max_Is_Reversed = false; //Is changing direction?
    private bool Back_Velocity_Max_Is_Reversed = false; //Is changing direction?

    private int Turn_Direction = 0;
    //Generic Movement Values

    //Boost
    public float Move_Boost_Max = 15;
    public float Move_Boost_Current = 0;

    public float Move_Boost_Boosting_Max = 0;
    public float Move_Boost_Boosting_Current = 0;

    private bool IsBoosting = false;

    [SerializeField] private float Move_Boost_Speed_Change_Forward = 0;
    [SerializeField] private float Move_Boost_Speed_Change_Turn = 0;
    [SerializeField] private float Move_Boost_Speed_Change_Decay = 0;
    //Boost

    //Weight Values, heavier objects move slower
    private float Mass;

    [SerializeField] private float Mass_Forward_Acceleration_Decrease = 0f;
    [SerializeField] private float Mass_Turn_Acceleration_Decrease = 0f;
    [SerializeField] private float Speed_Decay = 0f;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //This start function is not necessary, but it saves time if you do not want to customise all speed variables
        //Get Mass From Inspector
        rb = gameObject.GetComponent<Rigidbody>();

        Mass = rb.mass;

        //Check if a variable is assigned, if not assign a default value
        //Movement Generic
        if (Forward_Velocity_Max == 0)
        {
            Forward_Velocity_Max = Forward_Velocity_Increment * 1.5f;
        }

        if (Back_Velocity_Max == 0)
        {
            Back_Velocity_Max = Back_Velocity_Increment * -1.5f;
        }

        if (R_Turn_Velocity_Max == 0)
        {
            R_Turn_Velocity_Max = R_Turn_Velocity_Increment * 2;
        }

        if (L_Turn_Velocity_Max == 0)
        {
            L_Turn_Velocity_Max = L_Turn_Velocity_Increment * -2;
        }
        //Movement Generic

        //Movement Physics
        if (Mass_Forward_Acceleration_Decrease == 0)
        {
            Mass_Forward_Acceleration_Decrease = 1 / Mass;
        }

        if (Mass_Turn_Acceleration_Decrease == 0)
        {
            Mass_Turn_Acceleration_Decrease = 1 / Mass;
        }

        if (Speed_Decay == 0f)
        {
            Speed_Decay = Forward_Velocity_Increment * 0.5f; //Speed Decay defaults at 50% Speed Increase
        }
        //Movement Physics

        //Boost
        if (Move_Boost_Boosting_Max == 0)
        {
            Move_Boost_Boosting_Max = Move_Boost_Max / 3; //How long boost lasts
        }

        if (Move_Boost_Speed_Change_Forward == 0)
        {
            Move_Boost_Speed_Change_Forward = Forward_Velocity_Max * 0.5f; //Boost defaults at 50% Max Speed increase
        }

        if (Move_Boost_Speed_Change_Turn == 0)
        {
            Move_Boost_Speed_Change_Turn = (R_Turn_Velocity_Max - L_Turn_Velocity_Max) / 4; //Boost defaults at 25% Max Speed increase
        }

        if (Move_Boost_Speed_Change_Decay == 0)
        {
            Move_Boost_Speed_Change_Decay = Speed_Decay * 0.5f; //Speed decay halved while boosting
        }

        Move_Boost_Boosting_Current = Move_Boost_Boosting_Max;
        //Boost

        //Other
        Forward_Velocity_Max_Reversal = Forward_Velocity_Max * 1;
        Back_Velocity_Max_Reversal = Back_Velocity_Max * 1;
        //Other
    }

    void FixedUpdate()
    {
        MainLoop();
    }

    private void MainLoop()
    {
        if (Active)
        {
            CheckMove();
            CheckBoost();
            CheckTurn();

            //Increases velocity by speed and multiplies it by the multiplier
            //Velocity in forward direction, Time.deltaTime to make it unaffected by frame rate
            rb.velocity = transform.forward * Forward_Velocity_Current * GenericSpeedMultiplier * Time.deltaTime;
            //Rotate object on the Y axis
            transform.Rotate(new Vector3(0, -Turn_Direction, 0) * Turn_Velocity_Current * GenericSpeedMultiplier * Time.deltaTime, Space.World);
        }
        else
        {
            //Stop movement
            Forward_Velocity_Current = 0;
        }
    }

    private void CheckMove()
    {
        if (Input.GetKey("w") && Active)
        {
            if (Forward_Velocity_Current < 0)
            {
                //Was previously reversing
                if (!Forward_Velocity_Max_Is_Reversed)
                {
                    Forward_Velocity_Max_Is_Reversed = true;
                    Forward_Velocity_Max += Forward_Velocity_Max_Reversal;
                }
            }
            else
            {
                //Was previously moving forward
                if (Forward_Velocity_Max_Is_Reversed)
                {
                    Forward_Velocity_Max_Is_Reversed = false;
                    Forward_Velocity_Max -= Forward_Velocity_Max_Reversal;
                }
            }

            if (Forward_Velocity_Current < Forward_Velocity_Max)
            {
                //Object can still accelerate
                Forward_Velocity_Current += Forward_Velocity_Increment * Mass_Forward_Acceleration_Decrease * Time.deltaTime;
            }
            else
            {
                //Object going too fast and reset speed to the maximum
                Forward_Velocity_Current = Forward_Velocity_Max;
            }
        }
        else if (Input.GetKey("s") && Active)
        {
            if (Forward_Velocity_Current > 0)
            {
                //Was previously moving forward
                if (!Back_Velocity_Max_Is_Reversed)
                {
                    Back_Velocity_Max_Is_Reversed = true;
                    Back_Velocity_Max += Back_Velocity_Max_Reversal;
                }
            }
            else
            {
                //Was previously reversing
                if (Back_Velocity_Max_Is_Reversed)
                {
                    Back_Velocity_Max_Is_Reversed = false;
                    Back_Velocity_Max -= Back_Velocity_Max_Reversal;
                }
            }

            if (Forward_Velocity_Current > Back_Velocity_Max)
            {
                //Object can still accelerate
                Forward_Velocity_Current -= Back_Velocity_Increment * Mass_Forward_Acceleration_Decrease * Time.deltaTime;
            }
            else
            {
                //Object going too fast and reset speed to the maximum
                Forward_Velocity_Current = Back_Velocity_Max;
            }
        }
        else
        {
            //If stationary with no input this part of the code automatically slows the object
            if (Forward_Velocity_Current > 0)
            {
                Forward_Velocity_Current -= Speed_Decay / Mass * GenericSpeedDecayMultiplier * Time.deltaTime;
            }
            else if (Forward_Velocity_Current < -0.01)
            {
                Forward_Velocity_Current += Speed_Decay / Mass * GenericSpeedDecayMultiplier * Time.deltaTime;
            }
            else
            {
                //Object is now stationary
                Forward_Velocity_Current = 0;
            }
        }
    }

    private void CheckTurn()
    {
        //Gets input then turns along appropriate axis
        if (Input.GetKey("a"))
        {
            Turn_Direction = -1;
            if (Turn_Velocity_Current < L_Turn_Velocity_Max)
            {
                Turn_Velocity_Current += L_Turn_Velocity_Max * Mass_Turn_Acceleration_Decrease * Time.deltaTime;
            }
            else
            {
                Turn_Velocity_Current = L_Turn_Velocity_Max;
            }
        }
        else if (Input.GetKey("d"))
        {
            Turn_Direction = -1;
            if (Turn_Velocity_Current > R_Turn_Velocity_Max)
            {
                Turn_Velocity_Current -= R_Turn_Velocity_Increment * Mass_Turn_Acceleration_Decrease * Time.deltaTime;
            }
            else
            {
                Turn_Velocity_Current = R_Turn_Velocity_Max;
            }
        }
        else
        {
            if (Turn_Velocity_Current > 0)
            {
                Turn_Velocity_Current -= Speed_Decay / Mass * GenericSpeedDecayMultiplier * Time.deltaTime;
            }
            else if (Turn_Velocity_Current < -0.01)
            {
                Turn_Velocity_Current += Speed_Decay / Mass * GenericSpeedDecayMultiplier * Time.deltaTime;
            }
            else
            {
                Turn_Velocity_Current = 0;
            }
        }

        if (Input.GetKey("s"))
        {
            //When moving backwards turning must be reversed
            Turn_Direction *= -1;
        }
    }

    private void Boost(bool DirectionReversed = false)
    {
        int Direction;

        if (DirectionReversed)
        {
            Direction = -1; 
        }
        else
        {
            Direction = 1;
        }
        //This either increases speed by boost ammount or decreases (resets it back to normal)
        Forward_Velocity_Max += Move_Boost_Speed_Change_Forward * Direction;
        Back_Velocity_Max -= Move_Boost_Speed_Change_Forward * Direction;
        R_Turn_Velocity_Max += Move_Boost_Speed_Change_Turn * Direction;
        L_Turn_Velocity_Max -= Move_Boost_Speed_Change_Turn * Direction;
        Speed_Decay += Move_Boost_Speed_Change_Decay * Direction; 
    }

    private void CheckBoost()
    {
        //Calculates if there has been enough time since last boost
        if (Move_Boost_Current <= 0) 
        {
            if (Input.GetKey("left shift"))
            {
                //Applies boost to main speed variables
                IsBoosting = true;
                Move_Boost_Current = Move_Boost_Max;

                Boost();               
            }
        }
        else //Use else here so that the variable is not always being changed
        {
            //Counts how long since last boost
            Move_Boost_Current -= Time.deltaTime;
        }

        if (IsBoosting)//Could also use Invoke to reset the speed, however this is a slightly better method
        {
            Move_Boost_Boosting_Current -= Time.deltaTime;

            if (Move_Boost_Boosting_Current <= 0)
            {
                //Boost is over, reset the speed variables
                IsBoosting = false;
                Move_Boost_Boosting_Current = Move_Boost_Boosting_Max;

                Boost(true);
            }
        }

    }
}
