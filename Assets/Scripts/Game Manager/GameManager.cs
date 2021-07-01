using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Awake()
    {
        player.GetComponent<ThirdPersonMovement>().enabled = false;
        tutorialUI.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        MakeTutorialAppear();
    }

    [SerializeField] private GameObject tutorialUI;
    private bool isTutorialUIOn = true;
    void MakeTutorialAppear()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isTutorialUIOn)
            {
                player.GetComponent<ThirdPersonMovement>().enabled = false;
                tutorialUI.SetActive(true);
                isTutorialUIOn = true;
            }
            else
            {
                player.GetComponent<ThirdPersonMovement>().enabled = true;
                tutorialUI.SetActive(false);
                isTutorialUIOn = false;
            }
        }

    }
}
