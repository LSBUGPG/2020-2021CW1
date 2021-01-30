using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public Transform coinPosition;
    public float distance = 0.5f;
    public LayerMask playerLayer;
    private bool isTouching;

    private void Update()
    {
        isTouching = Physics.CheckSphere(coinPosition.position, distance, playerLayer);
        if (isTouching)
        {
            PlayerMovement.count += 1;
            Object.Destroy(gameObject);
        }
    }
}
