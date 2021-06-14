using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlate : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<FlowerPower>().weight < -1)
            {
                //Destroy floor
                Debug.Log("Destroy floor");
                return;
            }

            Debug.Log("Player is safe to cross");
        }
    }
}
