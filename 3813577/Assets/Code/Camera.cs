using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Camera1;
    void Start()
    {
        Camera1 = GetComponent<Transform>();
        Camera1.position = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
