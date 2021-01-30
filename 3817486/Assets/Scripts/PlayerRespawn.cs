using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPoint;

    private void OnTriggerEnter(Collider player)
    {
        Player.transform.position = RespawnPoint.transform.position;
    }
}
