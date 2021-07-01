using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseMemory : MonoBehaviour
{
    public static VaseMemory instance;
    public GameObject vase;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
}
