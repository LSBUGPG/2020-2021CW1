using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Vector3 startingPoint;

    void Start()
    {
        startingPoint = transform.position; 
    }

    public Vector3 OriginalPosition()
    {
        return startingPoint;
    }

    public bool HaveYouMoved()
    {
        float distance = Vector3.Distance(startingPoint, transform.position);

        if (distance > 0.5f)
        {
            return true;
        }

        return false;
    }

    public void ResetPosition()
    {
        transform.position = startingPoint;
    }
}
