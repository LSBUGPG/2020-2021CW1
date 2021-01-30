using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public GameObject Plant;
    public float waitFor;
    
    // Start is called before the first frame update
    void Start()
    {
       Destroy(Plant, waitFor);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
