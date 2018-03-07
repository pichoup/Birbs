using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbStatsPopup : MonoBehaviour {
    public PlayerHandler ph;

    public Text befriendText;
    public Text levelText;
    public Text ExperienceText;
    public Text statsText;
    public Text cooldownText;
    public Text feedBirbText;

    private BirbSlot _birbSlot;

    public void PopulatePopup(BirbSlot birbSlot)
    {
        _birbSlot.slotBirb = _birbSlot.slotBirb.SetBirbStats(_birbSlot.slotBirb);
        _birbSlot = birbSlot;


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
}
