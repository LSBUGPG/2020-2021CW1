using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class progressbar : MonoBehaviour
{ 
    public int current;
    public Slider fill;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        current = Raycast.CollectTotal;
    }

    void GetCurrentFill()

    {
        float fillAmount = (float)current;
        fill.value = fillAmount;
    }

}
