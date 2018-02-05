using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingHandler : BirbHandler<BreedingBirb> {
    public bool breeding;

    public Transform parentTransform;
    public GameObject parentBirbPrefab;

    private float timeSinceBothParentsInBreeder;

    public Birb egg;

    private void Start()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
    }

    public override bool TryAddBirb(Birb birb)
    {

        if (base.TryAddBirb(birb))
        {
            if (birbList.Count == maxBirbsInThisInventory)
                breeding = true;

            return true;
        }
        return false;
    }

    public override void UpdateBirbs(List<BreedingBirb> birbList, float time = 0f)
    {
        //FIX THIS
        //if both parents are there, start ticking, or else reset
        if (birbList.Count == 2)
        {
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
        else
        {
            timeSinceBothParentsInBreeder = 0f;
        }
    }

    private Birb TryMakeEgg(float breedTime1, float breedTime2)
    {
        if (timeSinceBothParentsInBreeder >= (breedTime1 + breedTime2) / 2f)
        {
            //TODO: fancy math here to calculate egg spawn chance
            Birb birb = new Birb();
            return birb.CreateNewBirbFromParents(birbList[0], birbList[1]);
                //new Birb(parents[0], parents[1]);
        }
        return null;
    }
}
