using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] private float sizeOfWind;
    void Update()
    {
        gameObject.GetComponent<BoxCollider>().size = new Vector3(10, sizeOfWind, 10); 
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<FlowerPower>().weight == 0)
        {
            other.GetComponent<ThirdPersonMovement>().characterVelocityMomentum += Vector3.up * 5;
            other.GetComponent<ThirdPersonMovement>().GravityStop();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(10, sizeOfWind, 10));
    }
}
