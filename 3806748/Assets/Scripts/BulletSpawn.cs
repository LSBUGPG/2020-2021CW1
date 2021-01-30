using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public KeyCode SpawnKey = KeyCode.Space;
    public GameObject BulletPrefab;

    public float ReloadRateMax = 1;

    private float ReloadRateCurrent;

    private void Start()
    {
        ReloadRateCurrent = ReloadRateMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (ReloadRateCurrent >= ReloadRateMax)
        {
            if (Input.GetKeyDown(SpawnKey))
            {
                ReloadRateCurrent = 0;

                GameObject tmp = Instantiate(BulletPrefab);
                tmp.transform.rotation = transform.rotation;
            }
        }
        else
        {
            ReloadRateCurrent += Time.deltaTime;
        }
    }
}
