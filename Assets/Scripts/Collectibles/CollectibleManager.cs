using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private GameObject seedTab;
    [SerializeField] private TextMeshProUGUI[] seedText;

    public List<Collectible> collectibles = new List<Collectible>();

    #region WhatTurtleToSpawn

    public bool isItTimeToCheckForTheEnd = false;

    [SerializeField] private GameObject noEndTurtle;
    [SerializeField] private GameObject endTurtle;



    [SerializeField] private Collectible testCollectible;

    #endregion

    private void Awake()
    {
        noEndTurtle.SetActive(false);
        endTurtle.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            seedTab.GetComponent<Animator>().SetBool("TabPressed", true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            seedTab.GetComponent<Animator>().SetBool("TabPressed", false);
        }


        if (endTurtle && noEndTurtle)
        {
            if (isItTimeToCheckForTheEnd)
            {
                CheckForWichTurtle();
            }
        }
    }
    public void AddCollectibleToList(Collectible collectible)
    {
        collectibles.Add(collectible);

        if (collectible.collectibleNumber == 3)
        {
            seedText[0].color = new Color(255, 152, 0);
        }

        if (collectible.collectibleNumber == 6)
        {
            seedText[1].color = new Color(255, 152, 0);
        }

        if (collectible.collectibleNumber == 4)
        {
            seedText[2].color = new Color(255, 152, 0);
        }

        if (collectible.collectibleNumber == 7)
        {
            seedText[3].color = new Color(255, 152, 0);
        }

        if (collectible.collectibleNumber == 5)
        {
            seedText[4].color = new Color(255, 152, 0);
        }
    }

    void CheckForWichTurtle()
    {
        if (collectibles.Count < 5)
        {
            noEndTurtle.SetActive(true);
            endTurtle.SetActive(false);
        }
        else
        {
            noEndTurtle.SetActive(false);
            endTurtle.SetActive(true);
        }
    }
}