using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCollider : MonoBehaviour
{
    [SerializeField] private GameObject parentIsland;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("This is happnening");
            other.transform.parent = parentIsland.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
