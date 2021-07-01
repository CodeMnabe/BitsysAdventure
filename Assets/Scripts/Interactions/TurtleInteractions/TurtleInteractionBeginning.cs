using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleInteractionBeginning : MonoBehaviour
{
    [SerializeField] private GameObject otherTurtle;
    [SerializeField] private GameObject badThing;

    public void NextTurtle()
    {
        gameObject.SetActive(false);
        otherTurtle.SetActive(true);

        badThing.SetActive(true);
    }
}
