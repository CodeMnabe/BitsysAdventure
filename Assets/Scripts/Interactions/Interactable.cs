using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Update()
    {
        if(isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }    
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            isInRange = true;
        }    
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            isInRange = false;
        }    
    }
}
