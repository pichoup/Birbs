using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Birb : ButtonLongPress
{
    public int speciesId;
    public BirbColors birbColor;
    public BirbImage birbImage;
    public List<Birb> parents = new List<Birb>();
    public BirbStatus status;
    public BirbStats stats;
    public Enums.BirbLocation birbLocation;

    public bool hatched;

    public void AddParent(Birb parent)
    {
        parents.Add(parent.GetCopy());
    }

    public void CreateNewBirbFromParents()
    {
        BirbColors tempColors = new BirbColors();

        //generate birb from parents if it has any, otherwise use default colours
        //TODO: make better algorithm here for getting parent traits
        if (parents.Count > 0)
        {
            tempColors.head = parents[Random.Range(0, parents.Count)].birbColor.head;
            tempColors.body = parents[Random.Range(0, parents.Count)].birbColor.body;
            tempColors.tail = parents[Random.Range(0, parents.Count)].birbColor.tail;
            tempColors.wings = parents[Random.Range(0, parents.Count)].birbColor.wings;
        }
        else
        {
            tempColors = GameObject.Find("CrappyDatabas").GetComponent<CrappyDatabase>().GetSpeciesById(speciesId).GetWeightedDefaultColor();
        }

        birbColor = tempColors.MutateColors(tempColors);
        birbImage = GameObject.Find("CrappyDatabas").GetComponent<CrappyDatabase>().GetSpeciesById(speciesId).image;
    }

    public Birb GetCopy()
    {
        return (Birb)this.MemberwiseClone();
    }


    public void TickBirb()
    {
        stats.growthPercent = Mathf.Clamp(stats.growthPercent + stats.growthRate, 0f, 100f);
        status.energy = Mathf.Clamp(status.energy + 0.5f, 0f, 100f);
        status.food = Mathf.Clamp(status.food - 0.5f, 0f, 100f);
        status.happiness = Mathf.Clamp(status.happiness + ((status.food - 50f) * 0.1f), 0f, 100f);
    }

    public void TappedBirb()
    {
        Debug.Log("<color=blue>TAPPED!</color>");
    }

    public void LongTappedBirb()
    {
        Debug.Log("<color=blue>LONG TAPPED!</color>");
    }
}
