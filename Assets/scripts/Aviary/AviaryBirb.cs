﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryBirb : Birb {
    public AviaryHandler ah;

    PlayerHandler ph;
    ModalHandler mh;

    public CollectableItem collectedItems;

    // Use this for initialization
    void Start () {
        ah = GameObject.FindGameObjectWithTag("AviaryHandler").GetComponent<AviaryHandler>();
        collectedItems = new CollectableItem();
	}

    public void TappedBirb()
    {
        CheckIfBirbCollectedAnything();
    }

    public void LongTappedBirb()
    {
        //TODO: open birb info instead
        MoveBirb(Enums.BirbLocation.NestParent);
    }

    public override void MoveBirb(Enums.BirbLocation location)
    {

    }

    public override void TickBirb(float time = 0f)
    {
        stats.growthPercent = Mathf.Clamp(stats.growthPercent + stats.growthRate, 0f, 100f);
        status.energy = Mathf.Clamp(status.energy + 0.5f, 0f, 100f);
        status.food = Mathf.Clamp(status.food - 0.5f, 0f, 100f);
        status.happiness = Mathf.Clamp(status.happiness + ((status.food - 50f) * 0.1f), 0f, 100f);
        status.collectItemTimer += 1f;

        //Birb Collected Stuff
        if (status.collectItemTimer >= stats.collectTime)
        {
            status.collectItemTimer = 0f;
            collectedItems.seeds += stats.collectAmount.seeds;
            collectedItems.worms += stats.collectAmount.worms;
            status.timesForagedItems += 1;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void CheckIfBirbCollectedAnything()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        ah.AddBirbDropsToInventory(collectedItems);
        collectedItems.seeds = 0;
        collectedItems.worms = 0;
    }
}
