using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BirbStats{
    public float growthPercent;
    public float growthRate;
    public float moveSpeed;
    public float sight;
    public float carryWeight;

    //Aviary
    public CollectableItem collectAmount;
    public float collectTime;

    //Breeder
    public float breedTime;
    public float hatchTime;
}
