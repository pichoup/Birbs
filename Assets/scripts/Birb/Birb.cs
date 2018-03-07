using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Birb : MonoBehaviour
{
    public int speciesId;
    public BirbColors birbColor;
    public BirbSprite birbSprite;
    public BirbStats birbStats;
    public bool isWildBirb;

    public BirbImage birbImage;

    public Birb SetBirbStats(Birb birb)
    {
        speciesId = birb.speciesId;
        birbColor = birb.birbColor;
        birbSprite = birb.birbSprite;
        birbStats = birb.birbStats;

        SetBirbSpritesAndColours();

        return (Birb)this.MemberwiseClone();
    }

    public void CreateRandomBirb(CrappyDatabase cd)
    {
        speciesId = cd.allBirbs[Random.Range(0, cd.allBirbs.Count)].id;
        BirbSpecies species = cd.GetSpeciesById(speciesId);
        birbColor = species.GetWeightedDefaultColor();
        birbSprite = species.sprite;
        birbStats.collectAmount.seeds = Random.Range(1, 5);
        birbStats.collectAmount.worms = Random.Range(1, 5);

        birbStats.befriendCost.seeds = Random.Range(50, 150);
        birbStats.befriendCost.worms = Random.Range(50, 150);

        SetBirbSpritesAndColours();
    }

    public void SetBirbSpritesAndColours()
    {
        birbImage.head.enabled = true;
        birbImage.body.enabled = true;
        birbImage.tail.enabled = true;
        birbImage.wings.enabled = true;

        birbImage.head.sprite = birbSprite.head;
        birbImage.body.sprite = birbSprite.body;
        birbImage.tail.sprite = birbSprite.tail;
        birbImage.wings.sprite = birbSprite.wings;
        birbImage.outline.sprite = birbSprite.outline;

        birbImage.head.color = birbColor.head;
        birbImage.body.color = birbColor.body;
        birbImage.tail.color = birbColor.tail;
        birbImage.wings.color = birbColor.wings;
    }

    public virtual void TappedBirb()
    {
        Debug.Log("Tapped");
    }

    public virtual void LongTappedBirb()
    {

    }
}
