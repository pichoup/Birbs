using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryBirb : Birb {

    PlayerHandler ph;
    ModalHandler mh;

    public CollectableItem collectedItems;

    // Use this for initialization
    void Start () {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        mh = GameObject.FindGameObjectWithTag("ModalHandler").GetComponent<ModalHandler>();
	}

    public void TappedBirb()
    {
        CheckIfBirbCollectedAnything();
    }

    public void LongTappedBirb()
    {
        //open birb modal
    }

    //TODO: Make this work==============================================================================================================================================
    public override void MoveBirb(Enums.BirbLocation location)
    {
        base.MoveBirb(location);
    }

    public void TickBirb()
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
        bool collectedStuff = false;

        //make collectable items a list or something in the future
        if (collectedItems.seeds > 0)
        {
            ph.collectableItems.seeds += collectedItems.seeds;
            mh.AddPopupToList("seeds", 0, collectedItems.seeds);
            collectedItems.seeds = 0;
            collectedStuff = true;
        }

        if (collectedItems.worms > 0)
        {
            ph.collectableItems.worms += collectedItems.worms;
            mh.AddPopupToList("worms", 1, collectedItems.worms);
            collectedItems.worms = 0;
            collectedStuff = true;
        }

        if (collectedStuff)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            mh.ShowPopups();
        }
    }
}
