using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotation : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.Rotate(0, Random.Range(0f, 30f), 0);
    }
}
