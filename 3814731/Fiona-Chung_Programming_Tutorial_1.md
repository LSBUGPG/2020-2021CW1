# Tutorial 1: Rotate a Clicked Object by 90 Degrees

Open up a 3D project in Unity and set the rotation in the project so that the scene view is the same as the game view. Create a cube with a scale where X is 2, Y is 4 and Z is 1.
Create a script called `RotateBlock` and make it a component of the cube/block in Unity. 

The Script:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlock : MonoBehaviour
{
    
    private Collider coll; 

    // Start is called before the first frame update
    void Start()
    {
        // The script uses the collider of the cube/block it is connected to, in order to register if the block has been clicked.
        // Make sure that the gameobject the script is attached to has a collider, otherwise this will not work.
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
    // When the mousebutton is pressed, then the object will rotate by 90 degrees.
        if (Input.GetMouseButtonDown(0))
        {
    // Starting point of the ray is from the camera and heads towards the mouse position.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
    // Checking if the collider was hit and where
    // ray = starting point, out hit = was raycast hit?, 100f = length of ray
            if (coll.Raycast(ray, out hit, 100f))
            {
    // Checking that the object that was hit has the correct collider tag.
                if(hit.collider.tag == "MyBlock")
                {
    // Rotate on the Z axis by 90 degrees (degrees are float values and require f to be written after the number). 
    //Vector3 must be used when working in 3D in Unity.
                    transform.Rotate(Vector3.back, 90f);
                }
            }
        }
    }
}
```

After writing the script, go back into Unity and make sure that the script and a collider is attached to the block. Then create the tag `MyBlock` in the inspector (located below the name of the game object) and add the tag to the block. 
