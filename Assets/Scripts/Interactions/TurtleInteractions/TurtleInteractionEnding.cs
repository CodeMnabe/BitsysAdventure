using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurtleInteractionEnding : MonoBehaviour
{
    [SerializeField] private GameObject previousTurtle;
    private void Awake() {
        previousTurtle.SetActive(false);
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Credit");
    }
}
