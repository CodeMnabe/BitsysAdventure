using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeFlower : MonoBehaviour
{
    [SerializeField] private GameObject flowerChangerBackground;
    [SerializeField] private OpenFlowerMenu menuObject;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI seedText;
    private FlowerPower flowerChanger;

    private void Awake()
    {
        flowerChanger = player.GetComponent<FlowerPower>();
        flowerChangerBackground.SetActive(false);
    }
    
    public void ChangeFlowerButton(string flowerName){
        flowerChanger.SwitchFlower(flowerName);
        player.GetComponent<ThirdPersonMovement>().isTalkingToSomeone = false;        
        seedText.text = "";
        seedText.gameObject.SetActive(false);
        flowerChangerBackground.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menuObject.NormalizeCamera();
    }
}
