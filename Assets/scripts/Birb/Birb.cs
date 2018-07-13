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

    public float timer;
    public GameObject popup;
    public PlayerHandler ph;

    private void Awake()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
    }

    public Birb SetBirbStats(Birb birb)
    {
        speciesId = birb.speciesId;
        birbColor = birb.birbColor;
        birbSprite = birb.birbSprite;
        birbStats = birb.birbStats;
        isWildBirb = birb.isWildBirb;

        SetBirbSpritesAndColours();
        timer = birbStats.collectTime;

        return (Birb)this.MemberwiseClone();
    }

    public void CreateRandomBirb(CrappyDatabase cd, bool wildBirb = true, CollectableItem inputItems = null, bool firstBirb = false)
    {
        inputItems = inputItems ?? new CollectableItem();

        speciesId = cd.allBirbs[Random.Range(0, cd.allBirbs.Count)].id;
        BirbSpecies species = cd.GetSpeciesById(speciesId);
        birbColor = species.GetWeightedDefaultColor();
        birbSprite = species.sprite;
        birbStats.collectAmount.seeds = Random.Range(5, 6);
        birbStats.collectAmount.worms = Random.Range(1, 2);
        birbStats.collectTime = Random.Range(5f, 6f);

        if (!firstBirb)
        {
            birbStats.befriendCost.seeds = Random.Range(30, 50);
            birbStats.befriendCost.worms = Random.Range(5, 20);
        }

        isWildBirb = wildBirb;
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
        if (popup.activeSelf)
        {
            popup.SetActive(false);

            //give players stuff here
            ph.AddResources(birbStats.collectAmount);
            timer = birbStats.collectTime;
        }
        else
        {
            ph.CheckStats(this);
        }
    }

    public virtual void LongTappedBirb()
    {
        Debug.Log("LongTappedBirb");
    }

    void Update()
    {
        if (!isWildBirb)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                CreatePopup();
            }
        }
    }

    private void CreatePopup()
    {
        popup.SetActive(true);
    }
}
