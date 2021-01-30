using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    GameObject[] boxes;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            //gameObject.transform.position = GameManager.lastCheckpoint.position;
            boxes = GameObject.FindGameObjectsWithTag("box");
            foreach (var item in boxes)
            {
                item.GetComponent<Box>().ResetPosition();
            }
        }
    }
}
