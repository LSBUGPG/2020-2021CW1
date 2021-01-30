using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject[] sides;
    public int result;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in sides)
        {
            if (i.GetComponent<Side>().onGround == true)
            {
                result = i.GetComponent<Side>().value;
                print(result);
            }
        }
    }
}
