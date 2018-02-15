using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBirb : Birb {
    public CollectionHandler ch;

    void Start()
    {
        ch = GameObject.FindGameObjectWithTag("CollectionHandler").GetComponent<CollectionHandler>();
    }

    public override bool MoveBirb(Enums.BirbLocation location)
    {
        if (base.MoveBirb(location))
        {
            ch.birbList.Remove(this);
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }

    public override void TappedBirb()
    {
        ch.CreateMoveBirbPopup(this);
    }
}
