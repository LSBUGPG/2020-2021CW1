using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public bool doorIsOpening;

    // Update is called once per frame
    void Update()
    {
        if (doorIsOpening == true)
        {
            Door.transform.Translate(Vector3.up * Time.deltaTime * 5);
            //if the bool is true open the door
        }
        if (Door.transform.position.y > 2.3f)
        {
            doorIsOpening = false;
            //if the y of the door is > 2f we want to stop the door from rising
        }
    }
    void OnMouseDown()
    {
        //this function will detect the mouse when it clicks on a collider, button.
        doorIsOpening = true;
        //if we click on the button door must start to open
    }
}
