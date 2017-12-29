using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Birb : MonoBehaviour
{
    public int speciesId;
    public BirbColors birbColor;
    public BirbImage birbImage;
    public List<Birb> parents = new List<Birb>();

    public bool hatched;

    public void AddParent(Birb parent)
    {
        parents.Add(parent.GetCopy());
    }

    public void CreateBirbFromParents()
    {
        BirbColors tempColors = new BirbColors();

        //generate birb from parents if it has any, otherwise use default colours
        if (parents.Count > 0)
        {
            tempColors.head = parents[Random.Range(0, parents.Count)].birbColor.head;
            tempColors.body = parents[Random.Range(0, parents.Count)].birbColor.body;
            tempColors.tail = parents[Random.Range(0, parents.Count)].birbColor.tail;
            tempColors.wings = parents[Random.Range(0, parents.Count)].birbColor.wings;
        }
        else
        {
            tempColors = new BirbSpecies().GetSpeciesById(speciesId).GetWeightedDefaultColor();
        }

        birbColor = tempColors.MutateColors(tempColors);
        birbImage = new BirbSpecies().GetSpeciesById(speciesId).image;
    }

    public Birb GetCopy()
    {
        return (Birb)this.MemberwiseClone();
    }
}
