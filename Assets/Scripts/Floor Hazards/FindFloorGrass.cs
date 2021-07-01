using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFloorGrass : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    void Awake()
    {
        gameObject.transform.Rotate(0, Random.Range(0, 360), 0);
        
        RaycastHit hit;

        if(Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity , groundMask))
        {
            transform.position = hit.point;
        }
    }
}
