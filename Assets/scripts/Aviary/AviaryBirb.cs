using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryBirb : Birb {
    public AviaryHandler ah;
    public GameObject itemNotification;

    public CollectableItem collectedItems;

    // Use this for initialization
    void Start () {
        ah = GameObject.FindGameObjectWithTag("AviaryHandler").GetComponent<AviaryHandler>();
        collectedItems = new CollectableItem();
	}

    public override void TappedBirb()
    {
        CheckIfBirbCollectedAnything();
    }

    public override void LongTappedBirb()
    {
        ah.CreateMoveBirbPopup(this);
    }

    public override bool MoveBirb(Enums.BirbLocation location)
    {
        if (base.MoveBirb(location))
        {
            ah.birbList.Remove(this);
            Destroy(this.gameObject);
            return true;
        }
        return false;
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
            itemNotification.SetActive(true);
        }
    }

    private void CheckIfBirbCollectedAnything()
    {
        itemNotification.SetActive(false);
        ah.AddBirbDropsToInventory(collectedItems);
        collectedItems.seeds = 0;
        collectedItems.worms = 0;
    }
}
