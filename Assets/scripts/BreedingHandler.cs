using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingHandler : BirbHandler<BreedingBirb> {
    private bool breeding;
    private float timeSinceBothParentsInBreeder;

    public Birb egg;

    public override void Start()
    {
        base.Start();
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
        if (breeding)
        {
            base.UpdateBirbs(birbList, time);
            timeSinceBothParentsInBreeder += time;

            bool canMakeEgg = egg == null ? true : false;
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
                egg = TryMakeEgg(birbList[0].stats.breedTime, birbList[1].stats.breedTime);
                if (egg != null)
                {
                    breeding = false;
                }
            }
        }
    }

    private Birb TryMakeEgg(float breedTime1, float breedTime2)
    {
        if (timeSinceBothParentsInBreeder >= (breedTime1 + breedTime2) / 2f)
        {
            //TODO: MAKE THIS WORK
            Birb birb = new Birb();
            return birb.CreateNewBirbFromParents(birbList[0], birbList[1]);
                //new Birb(parents[0], parents[1]);
        }
        return null;
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
