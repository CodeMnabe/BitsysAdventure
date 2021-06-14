using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyPlate : MonoBehaviour
{
    [SerializeField] private GameObject doorToOpen;
    [SerializeField] private Animator myAnimator;

    private bool playerNotStandingOnButton;
    private float timerToCloseDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<FlowerPower>().weight == 2)
            {
                playerNotStandingOnButton = false;
                myAnimator.SetBool("playerStandingOnTop", true);
                Debug.Log("Player is standing on top");
                doorToOpen.GetComponent<Animator>().SetBool("OpenDoor", true);
                return;
            }
            Debug.Log("Player doesn't have enough weight");
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerNotStandingOnButton = true;
        timerToCloseDoor = 4f;
    }

    private void Update()
    {
        if (doorToOpen)
        {
            if (playerNotStandingOnButton == true && timerToCloseDoor >= 0.01f)
            {
                timerToCloseDoor -= Time.deltaTime;
            }
            if (timerToCloseDoor <= 0.01f)
            {
                doorToOpen.GetComponent<Animator>().SetBool("OpenDoor", false);
                myAnimator.SetBool("playerStandingOnTop", false);
            }
        }
    }
}
