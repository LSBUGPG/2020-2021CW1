using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject rectangleSwitch;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem(){
        Vector3 playerPos = new Vector3(player.position.x, player.position.y + 1, player.position.z);
        Instantiate(rectangleSwitch, playerPos, Quaternion.identity);
    }
}
