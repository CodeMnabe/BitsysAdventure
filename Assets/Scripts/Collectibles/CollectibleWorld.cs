using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleWorld : MonoBehaviour
{
    private CollectibleManager collectibleManager;
    public Collectible collectible;

    [SerializeField] private Material[] myMaterial;

    private void Awake()
    {
        collectibleManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<CollectibleManager>();

        switch (collectible.typeOfCollectible)
        {
            case TypeOfCollectible.Hidden:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[2];
                break;
            case TypeOfCollectible.Match_the_Flower:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[0];
                break;
            case TypeOfCollectible.Start_a_Life:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[1];
                break;
            case TypeOfCollectible.Up_Challenge:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[3];
                break;
            case TypeOfCollectible.No_Jump_Challenge:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[4];
                break;
            case TypeOfCollectible.Light_Challenge:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[5];
                break;
            case TypeOfCollectible.Heavy_Challenge:
                gameObject.GetComponent<MeshRenderer>().material = myMaterial[6];
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
