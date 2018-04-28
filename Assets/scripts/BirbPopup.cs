using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbPopup : MonoBehaviour {
    public PlayerHandler ph;
    public BirbStatsPopup statsPopup;
    public Birb displayBirb;

    public Text befriendText;

    private BirbSlot _birbSlot;

    public void PopulatePopup(BirbSlot birbSlot)
    {
        _birbSlot = birbSlot;
        displayBirb.SetBirbStats(_birbSlot.slotBirb);

        befriendText.text = "Befriend birb\n- " + _birbSlot.slotBirb.birbStats.befriendCost.seeds + " Seeds\n- " + _birbSlot.slotBirb.birbStats.befriendCost.worms + " Worms";

    }

    public void OnTapElsewhere()
    {
        gameObject.SetActive(false);
    }

    public void CheckStats()
    {
        statsPopup.PopulatePopup(_birbSlot);
        statsPopup.gameObject.SetActive(true);
    } 

    public void TryBefriend()
    {
        if (ph.totalCollectableItems.seeds >= _birbSlot.slotBirb.birbStats.befriendCost.seeds && ph.totalCollectableItems.worms >= _birbSlot.slotBirb.birbStats.befriendCost.worms)
        {
            ph.totalCollectableItems.seeds -= _birbSlot.slotBirb.birbStats.befriendCost.seeds;
            ph.totalCollectableItems.worms -= _birbSlot.slotBirb.birbStats.befriendCost.worms;
            _birbSlot.AddBirbToCollection();
            gameObject.SetActive(false);
        }
    }

    public void IgnoreBirb()
    {
        _birbSlot.DestroyBirb();
        gameObject.SetActive(false);
    }
}
