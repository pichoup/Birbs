using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggBirb : Birb {

    public float hatchTimer;

    public Text birbText;

    public void TickBirb()
    {
        hatchTimer += 1f;
        if (hatchTimer >= stats.hatchTime)
        {
            HatchBirb();
        }
        if (!hatched)
        {
            birbText.text = "Time Left: " + (stats.hatchTime - hatchTimer);
        }
        else
        {
            birbText.text = "Hatched!";
        }
    }

    private void Start()
    {
        birbText = GameObject.FindGameObjectWithTag("BirbHatchTimer").GetComponent<Text>();
    }

    //TODO: Make this work==============================================================================================================================================
    public override void MoveBirb(Enums.BirbLocation location)
    {
        base.MoveBirb(location);
    }

    private void HatchBirb()
    {
        hatched = true;

        //Change egg sprite to hatched birb sprite
    }
}
