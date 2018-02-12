using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEggBirb : Birb {
    public BreedingHandler bh;

    void Start()
    {
        bh = GameObject.FindGameObjectWithTag("BreedingHandler").GetComponent<BreedingHandler>();
    }

    public override bool MoveBirb(Enums.BirbLocation location)
    {
        if (base.MoveBirb(location))
        {
            bh.egg = null;
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

    public override void TappedBirb()
    {
        
    }

    public override void LongTappedBirb()
    {
        
    }
}
