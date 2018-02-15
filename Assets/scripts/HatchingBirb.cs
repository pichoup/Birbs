using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchingBirb : Birb {
    public HatchingHandler hh;
    public float hatchTimer;

    void Start()
    {
        hh = GameObject.FindGameObjectWithTag("HatchingHandler").GetComponent<HatchingHandler>();
    }

    public override void TickBirb(float time = 0f)
    {
        hatchTimer += time;
        if (hatchTimer >= stats.hatchTime)
        {
            HatchBirb();
        }
    }

    public override bool MoveBirb(Enums.BirbLocation location)
    {
        if (base.MoveBirb(location))
        {
            hh.birbList.Remove(this);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

    private void HatchBirb()
    {
        hatched = true;
        SetBirbSpritesAndColours();
        //Change egg sprite to hatched birb sprite
    }

    public override void TappedBirb()
    {
        hh.CreateMoveBirbPopup(this);
    }
}
