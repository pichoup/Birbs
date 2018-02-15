using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionHandler : BirbHandler<CollectionBirb> {

    public override void Start()
    {
        handlerLocation = Enums.BirbLocation.Collection;
        base.Start();
    }

    public override bool TryAddBirb(Birb birb, Enums.BirbLocation location)
    {
        openBirbSlot = CheckForOpenBirbSlot();
        if (openBirbSlot >= 0)
        {
            Enums.BirbLocation initialLocation = location;

            GameObject go = Instantiate(birbPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(birbTransform);
            go.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            go.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            birbList.Add(go.GetComponent<CollectionBirb>());
            birbList[openBirbSlot].SetBirbStats(birb);
            birbList[openBirbSlot].birbLocation = location;
            return true;
        }
        return false;
    }
}
