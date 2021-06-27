using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFloorGrass : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    void Awake()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity , groundMask))
        {
            transform.position = hit.point;
        }
    }

    void Update()
    {

    }
}
