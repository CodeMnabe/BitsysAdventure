using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchAFlower : MonoBehaviour
{
    bool playerIsInPosition = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsInPosition = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsInPosition = false;
        }
    }

    private void Update()
    {
        if (playerIsInPosition == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            //SPAWN COLLECTIBLE
            Debug.Log("Spawn Collectible");
        }
    }

}
