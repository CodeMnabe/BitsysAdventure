using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject stopPlayer;
    [SerializeField] private GameObject textBackground; 
    [SerializeField] private TextMeshProUGUI displayText;
    [TextArea]
    [SerializeField] private string[] sentences;
    [SerializeField] private float typingSpeed;
    private int index;

    private bool textHasStarted;

    public UnityEvent actionAfterDialogue;

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Awake() {
        textBackground.SetActive(false);
    }

    public void StartDialogue()
    {
        textBackground.SetActive(true);
        if (!textHasStarted)
        {
            textHasStarted = true;
            StartCoroutine(Type());
            stopPlayer.GetComponent<ThirdPersonMovement>().isTalkingToSomeone = true;
            stopPlayer.GetComponent<ThirdPersonMovement>().myAnimator.ResetTrigger("Run");
            stopPlayer.GetComponent<ThirdPersonMovement>().myAnimator.SetTrigger("Idle");
        }
        else if(textHasStarted)
        {
            StopAllCoroutines();
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
            textBackground.SetActive(false);
            stopPlayer.GetComponent<ThirdPersonMovement>().isTalkingToSomeone = false;
            textHasStarted = false;
            index = 0;
            displayText.text = "";
            if(actionAfterDialogue != null)
            {
                actionAfterDialogue.Invoke();
            }
        }
    }
}
