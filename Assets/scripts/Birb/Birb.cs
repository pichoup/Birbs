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

    public Birb()
    {

    }

    public Birb (Enums.BirbLocation location, Birb parent1 = null, Birb parent2 = null)
    {
        if (parent1 != null)
            parents.Add(parent1.GetCopy());
        if (parent2 != null)
            parents.Add(parent2.GetCopy());

        //BirbColors tempColors = new BirbColors();

        //generate birb from parents if it has any, otherwise use defaults
        //TODO: make better algorithm here for getting parent traits
        if (parents.Count > 0)
        {
            //tempColors.head = parents[Random.Range(0, parents.Count)].birbColor.head;
            //tempColors.body = parents[Random.Range(0, parents.Count)].birbColor.body;
            //tempColors.tail = parents[Random.Range(0, parents.Count)].birbColor.tail;
            //tempColors.wings = parents[Random.Range(0, parents.Count)].birbColor.wings;
        }
        else
        {
            //tempColors = GameObject.Find("CrappyDatabas").GetComponent<CrappyDatabase>().GetSpeciesById(speciesId).GetWeightedDefaultColor();
        }

        //birbColor = tempColors.MutateColors(tempColors);
        //birbImage = GameObject.Find("CrappyDatabas").GetComponent<CrappyDatabase>().GetSpeciesById(speciesId).image;
    }

    public Birb GetCopy()
    {
        return (Birb)this.MemberwiseClone();
    }

    public virtual void MoveBirb(Enums.BirbLocation location)
    {
        if (location == birbLocation)
        {
            return;
        }
        else
        {
            Debug.LogError("Something probably went wrong");
        }
    }
}
