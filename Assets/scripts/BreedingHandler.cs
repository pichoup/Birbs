using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingHandler : MonoBehaviour {

    public BreedingBirb[] parents = new BreedingBirb[2];
    public float aviaryTickRate;
    private float timer;
    private float timeSinceBothParentsInBreeder;

    public Birb egg;
    public EggBirb hatchingBirb;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > aviaryTickRate)
        {
            timer = 0f;
            UpdateBreederBirbs(aviaryTickRate);
        }
    }

    public void UpdateBreederBirbs(float time = 0f)
    {
        //if both parents are there, start ticking, or else reset th
        if (parents[0] != null && parents[1] != null)
        {
            timeSinceBothParentsInBreeder += time;
            foreach (BreedingBirb bb in parents)
            {
                bb.TickBirb();
            }
            if (parents[0].canMakeEgg && parents[1].canMakeEgg)
            {
                TryMakeEgg(parents[0].stats.breedTime, parents[1].stats.breedTime);
            }
        }
        else
        {
            timeSinceBothParentsInBreeder = 0f;
        }
        if (hatchingBirb != null)
        {
            hatchingBirb.TickBirb();
        }
    }

    public bool TryAddParent(BreedingBirb parent)
    {
        if (parents[0] == null)
        {
            parents[0] = parent;
            return true;
        }
        else if (parents[1] == null)
        {
            parents[1] = parent;
            return true;
        }
        else {
            //add functionality here to remove old parents or something
            Debug.LogWarning("Both parent slots are full");
            return false;
        }
    }

    private void TryMakeEgg(float breedTime1, float breedTime2)
    {
        if (timeSinceBothParentsInBreeder >= (breedTime1 + breedTime2) / 2f)
        {
            //TODO: fancy math here to calculate egg spawn chance
            egg = new Birb(Enums.BirbLocation.NestParentsEgg, parents[0], parents[1]);
        }
    }
}
