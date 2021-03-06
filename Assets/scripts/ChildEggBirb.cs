﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEggBirb : Birb {
    public ChildEggHandler ceh;

    void Start()
    {
        ceh = GameObject.FindGameObjectWithTag("ChildEggHandler").GetComponent<ChildEggHandler>();
    }

    public override bool MoveBirb(Enums.BirbLocation location)
    {
        if (base.MoveBirb(location))
        {
            ceh.ResetBreeding();
            ceh.birbList.Remove(this);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

    public override void TappedBirb()
    {
        MoveBirb(Enums.BirbLocation.Collection);
    }

    public override void LongTappedBirb()
    {
        
    }
}
