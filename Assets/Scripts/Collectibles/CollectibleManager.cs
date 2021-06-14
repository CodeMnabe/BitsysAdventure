using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectiblesListUI;

    public List<Collectible> collectibles = new List<Collectible>();
    public void AddCollectibleToList(Collectible collectible)
    {        
        collectibles.Add(collectible);

        collectiblesListUI.text = "";
        foreach (Collectible collectibles in collectibles)
        {
            
            collectiblesListUI.text += collectibles.collectibleName + "<br>";
        }

    }

    private void Awake()
    {
        collectiblesListUI.text = "";
    }    
}