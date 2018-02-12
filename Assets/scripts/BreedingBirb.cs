using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingBirb : Birb {
    public BreedingHandler bh;

    public float breedTimer;
    public bool canMakeEgg;

    void Start()
    {
        bh = GameObject.FindGameObjectWithTag("BreedingHandler").GetComponent<BreedingHandler>();
    }

    public override void TickBirb(float time = 0f)
    {
        breedTimer += time;
        if (breedTimer >= stats.breedTime)
        {
            canMakeEgg = true;
        }
    }
    public override bool MoveBirb(Enums.BirbLocation location)
    {
        if (base.MoveBirb(location))
        {
            bh.ResetBreeding();
            bh.birbList.Remove(this);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

    public override void TappedBirb()
    {
        //CheckIfBirbCollectedAnything();
    }

    public override void LongTappedBirb()
    {
        bh.CreateMoveBirbPopup(this);
    }
}
