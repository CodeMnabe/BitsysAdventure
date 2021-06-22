using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI indicationText;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Update()
    {
        if(isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                indicationText.text = "";
                interactAction.Invoke();
            }
        }    
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            isInRange = true;
            indicationText.text = "Press " + interactKey.ToString() + " to interact";
        }    
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            isInRange = false;
            indicationText.text = "";
        }    
    }
}
