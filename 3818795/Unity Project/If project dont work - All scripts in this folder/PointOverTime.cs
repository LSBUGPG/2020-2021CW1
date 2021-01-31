using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOverTime : MonoBehaviour
{
    
    public static int score;
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("AddPoints", 1.0f, 5.0f);
    }

  

    void AddPoints()
    {
        score += 5;
    }
}
