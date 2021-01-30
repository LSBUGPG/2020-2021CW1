using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    private float z;
    Vector3 mouseDiff;

    private void OnMouseDown()
    {

        z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseDiff = gameObject.transform.position - MousePos();
        print("x");
    }
    private void OnMouseDrag()
    {
        transform.position = MousePos() + mouseDiff;
        //Vector3 vec = transform.position - (MousePos() + mouseDiff);

        //GetComponent<Rigidbody>().AddForce( vec * 2);
        print("y");
    }

    private Vector3 MousePos()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = z;

        return Camera.main.ScreenToViewportPoint(mouse);
    }
}
