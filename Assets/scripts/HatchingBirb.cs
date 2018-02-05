using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchingBirb : Birb {

    public float hatchTimer;

    public override void TickBirb(float time = 0f)
    {
        hatchTimer += time;
        if (hatchTimer >= stats.hatchTime)
        {
            HatchBirb();
        }
    }

    //TODO: Make this work==============================================================================================================================================
    public override bool MoveBirb(Enums.BirbLocation location)
    {
        base.MoveBirb(location);
        return false;
    }

    private void HatchBirb()
    {
        hatched = true;

        //Change egg sprite to hatched birb sprite
    }
}
