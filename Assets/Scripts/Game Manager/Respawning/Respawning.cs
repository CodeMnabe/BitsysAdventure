using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    public Vector3 respawnPoint;
    public Transform player;

    public void RespawnSystem()
    {
        player.position = respawnPoint;
        Physics.SyncTransforms();
    }    
}
