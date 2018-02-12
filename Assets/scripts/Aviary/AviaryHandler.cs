using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryHandler : BirbHandler<AviaryBirb> {

	// Use this for initialization
	public override void Start () {
        base.Start();
    }

    public void AddBirbDropsToInventory(CollectableItem ci)
    {
        bool aBirbCollectedStuff = false;

        //make collectable items a list or something in the future
        if (ci.seeds > 0)
        {
            ph.collectableItems.seeds += ci.seeds;
            mh.AddPopupToList("seeds", 0, ci.seeds);
            ci.seeds = 0;
            aBirbCollectedStuff = true;
        }

        if (ci.worms > 0)
        {
            ph.collectableItems.worms += ci.worms;
            mh.AddPopupToList("worms", 1, ci.worms);
            ci.worms = 0;
            aBirbCollectedStuff = true;
        }

        if (aBirbCollectedStuff)
        {
            mh.ShowPopups();
        }
    }

    protected override int GetMaxBirbsForThisInventory()
    {
        return birbTransform.childCount;
    }
}
