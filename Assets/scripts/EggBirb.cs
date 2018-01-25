using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBirb : Birb {

    public float hatchTimer;

    public void TickBirb()
    {
        hatchTimer += 1f;
        if (hatchTimer >= stats.hatchTime)
        {
            HatchBirb();
        }
    }

    //TODO: Make this work==============================================================================================================================================
    public override void MoveBirb(Enums.BirbLocation location)
    {
        base.MoveBirb(location);
    }

    private void HatchBirb()
    {
        hatched = true;

        //Change egg sprite to hatched birb sprite
    }
}
