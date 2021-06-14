using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObjects/Collectibles", order = 1)]
public class Collectible : ScriptableObject
{
    public int collectibleNumber;
    public string collectibleName;
    public TypeOfCollectible typeOfCollectible;
}

public enum TypeOfCollectible { Hidden, Match_the_Flower, Start_a_Life, Reach_the_End, Timed, Up_Challenge, No_Jump_Challenge, Light_Challenge, Heavy_Challenge}
