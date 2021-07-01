using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleWorld : MonoBehaviour
{
    private CollectibleManager collectibleManager;
    public Collectible collectible;

    [SerializeField] private Color[] myColor;
    [SerializeField] private Material seedMaterial;

    private void Awake()
    {
        seedMaterial = GetComponent<Renderer>().material;
        collectibleManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CollectibleManager>();

        switch (collectible.typeOfCollectible)
        {
            case TypeOfCollectible.Hidden:
                seedMaterial.color = myColor[2];
                break;
            case TypeOfCollectible.Match_the_Flower:
                seedMaterial.color = myColor[0];
                break;
            case TypeOfCollectible.Start_a_Life:
                seedMaterial.color = myColor[1];
                break;
            case TypeOfCollectible.Up_Challenge:
                seedMaterial.color = myColor[3];
                break;
            case TypeOfCollectible.No_Jump_Challenge:
                seedMaterial.color = myColor[4];
                break;
            case TypeOfCollectible.Light_Challenge:
                seedMaterial.color = myColor[5];
                break;
            case TypeOfCollectible.Heavy_Challenge:                
                seedMaterial.color = myColor[6];
                break;
            case TypeOfCollectible.Reach_the_End:                
                seedMaterial.color = myColor[7];
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectibleManager.AddCollectibleToList(collectible);
            Destroy(gameObject);
        }
    }
}
