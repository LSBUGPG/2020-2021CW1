using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject AllBlocks; //Groups all blocks under a single parent
    public GameObject Block; //The prefab you want to spawn
    public GameObject SpawnPos; //The object where you spawn prefab at

    public float TimerDelaySpawnMax = 1; //How long you are timed out from creating a prefab after each spawn

    private float TimerDelaySpawnCurrent; //Counts how long since last prefab spawn

    private void Start()
    {
        TimerDelaySpawnCurrent = TimerDelaySpawnMax; //Allows you to spawn a prefab from start of program
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerDelaySpawnCurrent >= TimerDelaySpawnMax) //If it's been long enough since last prefab spawn...
        {
            if (Input.GetMouseButtonUp(0)) //If let go of Left Mouse Click
            {
                TimerDelaySpawnCurrent = 0; //Reset timer as a new prefab is spawned

                //Create prefab "Block", spawn it at SpawnPos position, with a default rotation, and put it into the AllBlocks parent object
                Instantiate(Block, SpawnPos.transform.position, new Quaternion(), AllBlocks.transform);
            }
        }
        else //Count until it has been long enough from last spawn
        {
            TimerDelaySpawnCurrent += Time.deltaTime;
        }
    }
}
