using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleInteractionWithEnoughSeeds : MonoBehaviour
{
    [SerializeField] private GameObject badThing;
    [SerializeField] private GameObject badThingAnimation;
    [SerializeField] private GameObject nextTurtle;

    public void WinGame(){
        gameObject.SetActive(false);        
        nextTurtle.SetActive(true);
        badThing.SetActive(false);
        badThingAnimation.SetActive(true);
        Destroy(this);
    }
}
