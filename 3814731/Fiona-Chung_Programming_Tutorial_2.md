# Tutorial 2: Creating a Counter for the Rotation of a Block

This tutorial builds on the script and Unity project created in Tutorial 1. The counter shown here can also be adapted and used generally for when creating a counter that converts angles (float values) to integers. 

Adding to the script `RotateBlock` or after creating a new script in Unity, create a counter before `void Start`. The script must be a component of the object that is being rotated.
```
int Counter = 0;
```
If referencing `RotateBlock`, within `if (hit.collider.tag == "MyBlock")` change the contents to
```
// Adds 1 to the counter value every time the block is clicked/rotated.
Counter = Counter + 1;
// Rotates the block on the z axis by 90 degrees and multiplies the counter by 90
transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f * Counter);
```
To generally adapt this for another script, the counter and rotation must be added within the update or a new void function.

How the counter works:

0 * 90 = 0

1 * 90 = 90

2 * 90 = 180

3 * 90 = 270

By using the counter in this way, the degrees values are converted into integers that do not have decimal points. This gets rid of the possible error when using euler angles, for example when the rotation is not exactly 90 degrees. Depending on how many degrees a gameobject is supposed to be rotated, the counter could have more or less values than 0 to 3 as shown here.

Inside of `if (Input.GetMouseButtonDown(0))` add:
```
 if (Counter > 3)
            {
                Counter = 0;
            }
```
This sets the counter back to 0 once it reaches 4.

To view the counter during play in Unity:

Add 
```
Debug.Log(Counter);
```
to `if (coll.Raycast(ray, out hit, 100.0f))`.

To adapt this generally, the `if statement` and `Debug.Log` need to be added within the same function as the line that increases the counter by one and the `transform.rotation` previously written.

The full script (including the rotation of the block):
```
    private Collider coll;

    int Counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // The rotation only happens when the left mouse button is clicked.
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (coll.Raycast(ray, out hit, 100.0f))
            {
                if (hit.collider.tag == "MyBlock")
                {
                    Counter = Counter + 1;
                    transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f * Counter);
                }
                Debug.Log(Counter);
            }
            if (Counter > 3)
            {
                Counter = 0;
            }
        }
    }
    
