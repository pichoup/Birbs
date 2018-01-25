using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BirbSpecies {
    public int id;
    public string speciesName;
    public int rarity;
    public BirbImage image;
    public List<BirbColors> defaultColors;


    //temp
    public int seedDrops;
    public float dropCooldown;
    public int seedsToHatch;


    public BirbColors GetWeightedDefaultColor()
    {
        int weight = 0;
        for (int i = 0; i < defaultColors.Count; i++)
        {
            weight = weight + defaultColors[i].colorRarity;
        }

        int rand = Random.Range(0, weight);
        for (int j = 0; j < defaultColors.Count; j++)
        {
            if (rand < defaultColors[j].colorRarity)
            {
                return defaultColors[j];
            }
            rand = rand - defaultColors[j].colorRarity;
        }
        return new BirbColors();
    }
}
