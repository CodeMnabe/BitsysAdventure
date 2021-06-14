using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMechanism : MonoBehaviour
{
    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private GameObject objectNeeded;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == objectNeeded)
        {
            doorToOpen.GetComponent<Animator>().SetBool("OpenDoor", true);
        }
    }    
}
