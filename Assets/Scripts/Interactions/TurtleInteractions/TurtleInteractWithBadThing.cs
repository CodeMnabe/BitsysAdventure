using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleInteractWithBadThing : MonoBehaviour
{
    public void NextTurtle()
    {
        GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CollectibleManager>().isItTimeToCheckForTheEnd = true;
        gameObject.SetActive(false);
    }

}
