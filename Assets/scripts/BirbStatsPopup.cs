using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbStatsPopup : MonoBehaviour {
    public PlayerHandler ph;
    public Birb displayBirb;

    public Text levelText;
    public Text ExperienceText;
    public Text statsText;
    public Text cooldownText;
    public Text feedBirbText;

    private BirbSlot _birbSlot;
    public GameObject feedBirbButton;
    public GameObject playBirbButton;

    public void PopulatePopup(BirbSlot birbSlot)
    {
        _birbSlot = birbSlot;
        displayBirb.SetBirbStats(_birbSlot.slotBirb);

        feedBirbButton.SetActive(!displayBirb.isWildBirb);
        playBirbButton.SetActive(!displayBirb.isWildBirb);

        SetStats();
    }

    public void PopulatePopup(Birb birb)
    {
        displayBirb.SetBirbStats(birb);

        feedBirbButton.SetActive(!displayBirb.isWildBirb);
        playBirbButton.SetActive(!displayBirb.isWildBirb);
    }

    public void BackButton()
    {
        gameObject.SetActive(false);
    }

    public void FeedBirb()
    {

    }

    public void PetBirb()
    {

    }

    public void SetStats()
    {
        //Add all other text, give birbs leveling mechanics


        statsText.text = "Seeds: " + displayBirb.birbStats.collectAmount.seeds + " / s\nWorms: " +
            displayBirb.birbStats.collectAmount.worms + " / s\nCollect Cooldown: " +
            displayBirb.birbStats.collectTime + " s";
    }
}
