using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingBirb : Birb {

    public float breedTimer;
    public bool canMakeEgg;

    public override void TickBirb(float time = 0f)
    {
        //TODO: MAKE THIS WORK
        breedTimer += 1f;
        if (breedTimer >= stats.breedTime)
        {
            canMakeEgg = true;
        }
    }

    //TODO: Make this work==============================================================================================================================================
    public override bool MoveBirb(Enums.BirbLocation location)
    {
        base.MoveBirb(location);
        return false;
    }

    public void TappedBirb()
    {
        //CheckIfBirbCollectedAnything();
    }

    public void LongTappedBirb()
    {
        //open birb modal
    }
}
