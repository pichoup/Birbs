using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchingHandler : BirbHandler<HatchingBirb> {
    public Text birbText;

    public override void Start()
    {
        handlerLocation = Enums.BirbLocation.NestHatching;
        base.Start();
        birbText = GameObject.FindGameObjectWithTag("BirbHatchTimer").GetComponent<Text>();
    }

    public override void UpdateBirbs(List<HatchingBirb> birbList, float time = 0f)
    {
        base.UpdateBirbs(birbList, time);

        if (birbList.Count >= 1)
        {
            if (!birbList[0].hatched)
            {
                birbText.text = "Time Left: " + (birbList[0].stats.hatchTime - birbList[0].hatchTimer);
            }
            else
            {
                birbText.text = "Hatched!";
            }
        }
    }

    public override bool TryAddBirb(Birb birb, Enums.BirbLocation location)
    {
        openBirbSlot = CheckForOpenBirbSlot();
        if (openBirbSlot >= 0)
        {
            GameObject go = Instantiate(birbPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(birbTransform);
            go.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            go.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            birbList.Add(go.GetComponent<HatchingBirb>());
            birbList[openBirbSlot].SetBirbStats(birb);
            birbList[openBirbSlot].birbLocation = location;
            return true;
        }
        return false;
    }
}
