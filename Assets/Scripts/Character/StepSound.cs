using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{ 
    public void playStepSound()
    {
        FindObjectOfType<AudioManager>().Play("FootStep");
    }
}
