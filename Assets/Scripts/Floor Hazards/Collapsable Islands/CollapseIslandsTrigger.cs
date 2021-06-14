using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseIslandsTrigger : MonoBehaviour
{
    [SerializeField] private GameObject parentIsland;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            parentIsland.GetComponent<CollapsableIslands>().StartFallTimer();
        }
    }
}
