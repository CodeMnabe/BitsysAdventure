using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRespawnPoint : MonoBehaviour
{
    private Respawning respawnPoint;
    private Vector3 checkpointPosition;
    private float y;

    private void Awake()
    {
        respawnPoint = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<Respawning>();
        checkpointPosition = this.transform.position;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out RaycastHit hit))
        {
            y = (float)(hit.point.y + 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            respawnPoint.respawnPoint = checkpointPosition;
            respawnPoint.respawnPoint.y = y;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(this.transform.localScale.x,this.transform.localScale.y, this.transform.localScale.z));
    }
}
