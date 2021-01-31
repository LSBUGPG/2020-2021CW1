using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollowplayer : MonoBehaviour {
    public GameObject face;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - face.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = face.transform.position + offset;
    }
}
