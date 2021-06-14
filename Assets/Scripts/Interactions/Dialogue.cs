using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject stopPlayer;
    [SerializeField] private TextMeshProUGUI displayText;
    [TextArea]
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed;
    private int index;

    private bool textHasStarted;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartDialogue()
    {
        if (!textHasStarted)
        {
            textHasStarted = true;
            StartCoroutine(Type());
            stopPlayer.GetComponent<ThirdPersonMovement>().isTalkingToSomeone = true;
        }
        else if(textHasStarted)
        {
            NextSentence();
        }

    }

    private void NextSentence()
    {
        if(index < sentences.Length - 1)
        {            
            index++;
            displayText.text = "";
            StartCoroutine(Type());
        }
        else
        {
            stopPlayer.GetComponent<ThirdPersonMovement>().isTalkingToSomeone = false;
            textHasStarted = false;
            index = 0;
            displayText.text = "";
        }
    }
}
