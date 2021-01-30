using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryReveal : MonoBehaviour
{
    private static int itemCount;
    public GameObject victoryCapsule;

    // Start is called before the first frame update
    void Start()
    {
        victoryCapsule.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        itemCount = CollectItem.items;

        if(itemCount > 3)
        {
            victoryCapsule.SetActive(true);
        }
    }
}
