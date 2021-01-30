using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 10;

    public float MoveDelay = 1f;

    private float MoveDelayCurrent;

    private void Start()
    {
        MoveDelayCurrent = MoveDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveDelayCurrent >= MoveDelay)
        {
            MoveDelayCurrent = 0;
            transform.position += -transform.forward * Time.deltaTime * Speed;
        }
        else
        {
            MoveDelayCurrent += Time.deltaTime;
        }
    }
}
