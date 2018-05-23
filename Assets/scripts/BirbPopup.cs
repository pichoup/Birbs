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

        befriendText.text = "Befriend birb\n- " + _birbSlot.slotBirb.birbStats.minimumFeederAmount.seeds + " Seeds\n- " + _birbSlot.slotBirb.birbStats.minimumFeederAmount.worms + " Worms";

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
        if (CollectableItem.HasEnoughResources(ph.totalCollectableItems, _birbSlot.slotBirb.birbStats.minimumFeederAmount))
        {
            ph.totalCollectableItems = CollectableItem.Subtract(ph.totalCollectableItems, _birbSlot.slotBirb.birbStats.minimumFeederAmount);
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
