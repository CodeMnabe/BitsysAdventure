using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI indicationText;
    [SerializeField] private GameObject textBackground;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                textBackground.SetActive(false);
                indicationText.text = "";
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            textBackground.SetActive(true);
            indicationText.text = "Press " + interactKey.ToString() + " to interact";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            if (textBackground == null)
            {
                Debug.Log(gameObject.name);
            }
            else
            {
                textBackground.SetActive(false);
            }

            indicationText.text = "";
        }
    }
}
