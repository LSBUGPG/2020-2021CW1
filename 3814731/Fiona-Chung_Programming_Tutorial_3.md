# Tutorial 3: Checking the Orientation of a Rectangular Block
This requires a script to be attached to an object that is rotated by a counter. In this case the object is being rotated by 90 degrees when the left mouse button is clicked. The gameobject is a cube of where the scale of X is 2, Y is 4 and Z is 1; making the cube a rectangle. The rectangular gameobject is important to this script, as when a rectangle is rotated, it is vertical at both 0 and 180 degrees, and it is horizontal at both 90 and 270 degrees. By making use of the block being rotated by a counter rather than the euler angles, this tutorial sets up code that identifies when the rotated block is in a horizontal or vertical position.

#### 1) Randomize the orientation of blocks
To randomize the orientation at the start of the play the line of code must be written in `start`. 
Making use of the counter, the counter is randomized from a range of 0 to 3. This makes use of `Random.Range`. 
For `Random.Range(0, 4)` 0 is the starting number and since the last number is excluded, the second number must be set to 4 instead of 3. 
```Counter = Random.Range(0, 4);```

#### 2) Set up a correct orientation that can be entered for each block individually in the inspector and check if the orientation of the block is equal to the winning orientation
For this you need to make two public booleans before start and update, `setVeritical` and `setHorizontal`. By making these booleans public, it is then possible to set them to either true of false in the inspector. They will control what the correct/winning orientation of the block is. 
```
    public bool setVertical;
    public bool setHorizontal;
```

Then set up another pair of booleans, `verticalCount` and `horizontalCount` (these do not need to be public as they are only used in the script itself). 
```
    bool verticalCount = false;
    bool horizontalCount = false;
```

After this set up an `if` and `if else` statement. These statements take the count values and group them into `verticalCount` or `horizontalCount`. 
By doing this the next set of `if statements` can check if the block orientation is the same as the set winning orientation. 
These `if statements` require either the booleans of `setVeritcal` and `verticalCount`, or `setHorizontal` and `horizontalCount` to be equal to true. 
```
        if (Counter == 0 || Counter == 2)
        {
            verticalCount = true;
            horizontalCount = false;
        }
        else if (Counter == 1 || Counter == 3) 
        {
            horizontalCount = true;
            verticalCount = false; 
        }

        if (verticalCount == true && SetVertical == true)
        {
        
        }
        if (horizontalCount == true && SetHorizontal == true) 
        {

        }
```
When duplicating the blocks inside of Unity in the hierarchy, each one can be individually set to horizontal or vertical. A `Debug.Log("");` can be added within the second set of `if statements` to check that the orientation of the blocks are being identified correctly. 


The full script (includes code for the counter and rotation of the block as well):
```
 private Collider coll;

    public int Counter = 0;
    
    // Public booleans to set the positions for the block.
    public bool setVertical;
    public bool setHorizontal;
    
    // Booleans that correspond to the count values.
    bool verticalCount = false;
    bool horizontalCount = false;
    
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();

        // Sets the counter to a random number of either 0, 1, 2 or 3 at the start.
        Counter = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "MyBlock")
                {
                    Counter = Counter + 1;
                    if (Counter > 3)
                    {
                        Counter = 0;
                    }
                }
            }
        }
        // Transform must be outside of the if statements so that the block is being rotated by the counter, rather than by euler angles.
        // This allows the rotation of the block to be randomized by positions of 90, 180, and so on on the Z axis.
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f * Counter);
        
        // Checks if the block is in a vertical position
         if (Counter == 0 || Counter == 2)
        {
            // Sets the verticalCount to true and the horizontalCount to false. It does the opposite in else if.
            verticalCount = true;
            horizontalCount = false;
        }
        // Checks if the block is in a horizontal position
        else if (Counter == 1 || Counter == 3) 
        {
            horizontalCount = true;
            verticalCount = false; 
        }

        // The if statements check if what the correct position the block has been set to matches it's current position. 
        if (verticalCount == true && SetVertical == true)
        {

        }
        if (horizontalCount == true && SetHorizontal == true) 
        {

        }
    }
```
