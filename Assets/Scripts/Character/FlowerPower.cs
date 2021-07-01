using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPower : MonoBehaviour
{
    public int weight;
    [SerializeField] private float initialHeight;
    private Transform myTransform;
    private CharacterController charController;
    private ThirdPersonMovement playerScript;
    public Flower currentFlower;

    [SerializeField] private Material backMaterial;
    [SerializeField] private Color[] myColors;
    public enum Flower
    {
        Lily,//neutral flower
        Tulip, //Size up
        Poppy, //Size down
        Waterflower, //Extra jump height
    }

    private void Start()
    {
        playerScript = GetComponent<ThirdPersonMovement>();
        charController = GetComponent<CharacterController>();
        myTransform = GetComponent<Transform>();
        currentFlower = Flower.Lily;
    }
    private void Update()
    {
        switch (currentFlower)
        {
            case Flower.Lily:
                ResetJumpHeight();
                ResetWeight();
                ResetScale();
                backMaterial.color = myColors[0];
                break;
            case Flower.Tulip:
                ResetJumpHeight();
                weight = 2;
                myTransform.localScale = new Vector3(1 * 1.2f, 1 * 1.2f, 1 * 1.2f);
                backMaterial.color = myColors[1];
                break;
            case Flower.Poppy:
                ResetJumpHeight();
                weight = 0;
                myTransform.localScale = new Vector3(1 / 1.2f, 1 / 1.2f, 1 / 1.2f);
                backMaterial.color = myColors[2];
                break;
            case Flower.Waterflower:
                ResetScale();
                ResetWeight();
                playerScript.jumpHeight = playerScript.startJumpHeight * 1.8f;
                backMaterial.color = myColors[3];
                break;
            default:
                break;
        }
    }

    public void SwitchFlower(string flowerName)
    {
        switch (flowerName)
        {
            case "Lily":
                currentFlower = Flower.Lily;
                break;
            case "Tulip":
                currentFlower = Flower.Tulip;
                break;
            case "Poppy":
                currentFlower = Flower.Poppy;
                break;
            case "Waterflower":
                currentFlower = Flower.Waterflower;
                break;
            default:
                break;
        }
    }

    private void ResetWeight()
    {
        weight = 1;
    }
    private void ResetScale()
    {
        myTransform.localScale = new Vector3(1, 1, 1);
    }
    private void ResetJumpHeight()
    {
        playerScript.jumpHeight = playerScript.startJumpHeight;
    }
}
