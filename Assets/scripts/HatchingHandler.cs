﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HatchingHandler : BirbHandler<HatchingBirb> {
    public Text birbText;

    private void Start()
    {
        birbText = GameObject.FindGameObjectWithTag("BirbHatchTimer").GetComponent<Text>();
    }

    public override void UpdateBirbs(List<HatchingBirb> birbList, float time = 0f)
    {
        base.UpdateBirbs(birbList, time);

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
