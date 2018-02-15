using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEggHandler : BirbHandler<ChildEggBirb> {
    public BreedingHandler bh;

    public override void Start()
    {
        handlerLocation = Enums.BirbLocation.NestParentsEgg;
        base.Start();
        bh = GameObject.FindGameObjectWithTag("BreedingHandler").GetComponent<BreedingHandler>();
    }

    public void TryMakeEgg()
    {
        Birb egg = MakeEgg(bh.birbList[0].stats.breedTime, bh.birbList[1].stats.breedTime);
        if (egg != null)
        {
            birbList.Add(egg as ChildEggBirb);
            bh.breeding = false;
        }
    }

    public Birb MakeEgg(float breedTime1, float breedTime2)
    {
        if (bh.timeSinceBothParentsInBreeder >= (breedTime1 + breedTime2) / 2f)
        {
            GameObject go = Instantiate(birbPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(birbTransform);
            go.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            go.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            Birb birb = go.GetComponent<Birb>().CreateNewBirbFromParents(bh.birbList[0], bh.birbList[1]);
            birb.birbLocation = Enums.BirbLocation.NestParentsEgg;
            ph.allPlayerBirbs.Add(birb);
            return birb;
        }
        return null;
    }

    public void ResetBreeding()
    {
        bh.ResetBreeding();
    }
}
