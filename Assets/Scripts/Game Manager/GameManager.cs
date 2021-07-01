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
        MakeTutorialAppear();
        PauseGame();
    }

    [SerializeField] private GameObject tutorialUI;
    private bool isTutorialUIOn = true;
    void MakeTutorialAppear()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isPaused)
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

    [SerializeField] private GameObject pauseUI;
    private bool isPaused;
    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                pauseUI.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    public void Unpause()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
