using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingHandler : BirbHandler<BreedingBirb> {
    public ChildEggHandler ceh;

    public bool breeding;
    public float timeSinceBothParentsInBreeder;

    public override void Start()
    {
        handlerLocation = Enums.BirbLocation.NestParent;
        base.Start();
        ceh = GameObject.FindGameObjectWithTag("ChildEggHandler").GetComponent<ChildEggHandler>();
    }

    public override bool TryAddBirb(Birb birb, Enums.BirbLocation location)
    {
        if (base.TryAddBirb(birb, location))
        {
            ResetBreeding();
            return true;
        }
        return false;
    }

    //birbs try to breed until an egg is made
    public override void UpdateBirbs(List<BreedingBirb> birbList, float time = 0f)
    {
        if (breeding && birbList.Count == 2)
        {
            base.UpdateBirbs(birbList, time);
            timeSinceBothParentsInBreeder += time;

            bool canMakeEgg = ceh.birbList.Count == 0 ? true : false;
            foreach (BreedingBirb bb in birbList)
            {
                bb.TickBirb();
                if (!bb.canMakeEgg)
                {
                    canMakeEgg = false;
                }
            }
            if (canMakeEgg)
            {
                ceh.TryMakeEgg();
            }
        }
    }

    public void ResetBreeding(bool breed = true)
    {
        //if both parents are full, start breeding and reset the breed timer
        if (birbList.Count == maxBirbsInThisInventory)
        {
            breeding = breed;
            timeSinceBothParentsInBreeder = 0f;
        }
    }
}
