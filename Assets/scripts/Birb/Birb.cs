﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Birb : MonoBehaviour
{
    public int speciesId;
    public BirbColors birbColor;
    public BirbImage birbImage;
    public List<Birb> parents;
    public BirbStatus status;
    public BirbStats stats;
    public Enums.BirbLocation birbLocation;
    public bool hatched;
    public ButtonLongPress blp;

    private void Awake()
    {
        blp = GetComponent<ButtonLongPress>();
    }

    public Birb SetBirbStats(Birb birb)
    {
        speciesId = birb.speciesId;
        birbColor = birb.birbColor;
        birbImage = birb.birbImage;
        parents = birb.parents;
        status = birb.status;
        stats = birb.stats;
        birbLocation = birb.birbLocation;
        return (Birb)this.MemberwiseClone();
    }

    public Birb CreateNewBirbFromParents (Birb parent1, Birb parent2)
    {
        parents.Add(parent1.GetCopy());
        parents.Add(parent2.GetCopy());
        parents = new List<Birb>();
        hatched = false;

        int species = Random.Range(0, parents.Count);
        speciesId = parents[species].speciesId;
        birbImage = parents[species].birbImage;

        BirbColors tempColors = new BirbColors();
        //generate birb from parents if it has any, otherwise use defaults
        //TODO: make better algorithm here for getting parent traits
        tempColors.head = parents[Random.Range(0, parents.Count)].birbColor.head;
        tempColors.body = parents[Random.Range(0, parents.Count)].birbColor.body;
        tempColors.tail = parents[Random.Range(0, parents.Count)].birbColor.tail;
        tempColors.wings = parents[Random.Range(0, parents.Count)].birbColor.wings;

        birbColor = tempColors.MutateColors(tempColors);

        stats.breedTime = parents[Random.Range(0, parents.Count)].stats.breedTime;
        stats.carryWeight = parents[Random.Range(0, parents.Count)].stats.carryWeight;
        stats.collectAmount = parents[Random.Range(0, parents.Count)].stats.collectAmount;
        stats.collectTime = parents[Random.Range(0, parents.Count)].stats.collectTime;
        stats.growthPercent = 0f;
        stats.growthRate = parents[Random.Range(0, parents.Count)].stats.growthRate;
        stats.hatchTime = parents[Random.Range(0, parents.Count)].stats.hatchTime;
        stats.moveSpeed = parents[Random.Range(0, parents.Count)].stats.moveSpeed;
        stats.sight = parents[Random.Range(0, parents.Count)].stats.sight;

        return (Birb)this.MemberwiseClone();

        //else
        //{
        //    //tempColors = GameObject.Find("CrappyDatabas").GetComponent<CrappyDatabase>().GetSpeciesById(speciesId).GetWeightedDefaultColor();
        //}

        //birbImage = GameObject.Find("CrappyDatabas").GetComponent<CrappyDatabase>().GetSpeciesById(speciesId).image;
    }  

    public Birb GetCopy()
    {
        return (Birb)this.MemberwiseClone();
    }

    public virtual bool MoveBirb(Enums.BirbLocation destination)
    {
        if (destination == birbLocation)
        {
            return false;
        }
        else
        {


            switch (destination)
            {
                case Enums.BirbLocation.Aviary:
                    if (GameObject.FindGameObjectWithTag("AviaryHandler").GetComponent<AviaryHandler>().TryAddBirb(this, Enums.BirbLocation.Aviary))
                    {
                        return true;
                    }
                    break;

                case Enums.BirbLocation.NestParent:
                    if (GameObject.FindGameObjectWithTag("BreedingHandler").GetComponent<BreedingHandler>().TryAddBirb(this, Enums.BirbLocation.NestParent))
                    {
                        return true;
                    }
                    break;
            }
        }
        return false;
    }

    public virtual void TickBirb(float time = 0f)
    {
        Debug.Log("somethign went wrong");
    }
}
