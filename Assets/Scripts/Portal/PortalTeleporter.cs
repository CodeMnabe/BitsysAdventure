using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;             //Put player in inspector
    public Transform receiver;           //Put the other portal's collider in the inspector

    private bool playerIsOverlapping = false;

    void Update()
    {
        if (playerIsOverlapping)
        {
            //Get the position from the player to the portal
            Vector3 portalToPlayer = player.position - transform.position;

            //Make the dot product between the player and this portal
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);


            //If the player passes through the portal
            if (dotProduct < 0f)
            {
                //Get the rotational difference between both portals
                float rotationDiff = Quaternion.Angle(transform.rotation, receiver.rotation);
                //Rotate it 180 degrees
                rotationDiff += 180f;
                //Rotate the player
                player.Rotate(Vector3.up, rotationDiff);

                //Get the position Offset from the rotational difference from the player to the portal
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                //Teleport the player
                player.GetComponent<CharacterController>().enabled = false;
                player.position = receiver.position + positionOffset;
                player.GetComponent<CharacterController>().enabled = true;

                //Make the player not overlap
                playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
