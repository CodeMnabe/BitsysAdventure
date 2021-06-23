using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectiblesListUI;

    [SerializeField] private TextMeshProUGUI[] seedText;

    public List<Collectible> collectibles = new List<Collectible>();
    public void AddCollectibleToList(Collectible collectible)
    {        
        collectibles.Add(collectible);

        if(collectible.collectibleNumber == 3)
        {
            seedText[0].color = new Color(255, 152, 0);
        }

        if(collectible.collectibleNumber == 6)
        {
            seedText[1].color = new Color(255, 152, 0);
        }

        if(collectible.collectibleNumber == 4)
        {
            seedText[2].color = new Color(255, 152, 0);
        }

        if(collectible.collectibleNumber == 7)
        {
            seedText[3].color = new Color(255, 152, 0);
        }

        if(collectible.collectibleNumber == 5)
        {
            seedText[4].color = new Color(255, 152, 0);
        }
    }

    private void Awake()
    {
        collectiblesListUI.text = "";
    }    
}