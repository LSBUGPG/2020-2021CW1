using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    SphereCollider theCollider;
    // Start is called before the first frame update
    void Awake()
    {
        theCollider = GetComponent<SphereCollider>();
        TurnOffCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnCollider()
    {
        theCollider.enabled = true;
        
    }

    public void TurnOffCollider()
    {
        theCollider.enabled = false;
        
    }
}
