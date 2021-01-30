using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurseScript : MonoBehaviour
{
    public Transform pursePosition;
    public float distance = 0.5f;
    public LayerMask playerLayer;
    private bool isTouching;
    public Text winText;

    private void Start()
    {
        winText.enabled = false;  
    }

    private void Update()
    {
        isTouching = Physics.CheckSphere(pursePosition.position, distance, playerLayer);
        if (isTouching)
        {
            winText.enabled = true;
            Debug.Log("Yoy win");
            Object.Destroy(gameObject);
        }
    }
}
