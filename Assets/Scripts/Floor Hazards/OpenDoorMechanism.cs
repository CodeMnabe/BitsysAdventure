using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMechanism : MonoBehaviour
{
    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private GameObject objectNeeded;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Something has collided");
        if(other.gameObject == objectNeeded)
        {
            Debug.Log("This is happening");
            doorToOpen.GetComponent<Animator>().SetBool("OpenDoor", true);
        }
    }    
}
