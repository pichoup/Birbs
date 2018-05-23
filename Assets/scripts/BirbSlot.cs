using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbSlot : MonoBehaviour {
    public Birb slotBirb;
    public CollectableItem unlockCost;
    public CollectableItem slotItems;
    public PlayerHandler ph;
    public FeederCycler fc;

    public GameObject birbPopupModal;
    public GameObject birbPrefab;

    public float timer = 2f;
    public bool unlocked;
    public bool canAttractBirb;

    private void Start()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        fc = transform.parent.GetComponent<FeederCycler>();
    }

    private void TryUnlock()
    {
        if (ph.totalCollectableItems.seeds >= unlockCost.seeds && ph.totalCollectableItems.worms >= unlockCost.worms)
        {
            unlocked = true;
            ph.totalCollectableItems.seeds -= unlockCost.seeds;
            ph.totalCollectableItems.worms -= unlockCost.worms;
            fc.UpdateBirbSlots();
            transform.GetChild(0).GetComponent<Text>().enabled = false;
        }
    }

    public void OnTap()
    {
        if (unlocked)
        {
            if (slotBirb != null)
            {
                birbPopupModal.GetComponent<BirbPopup>().PopulatePopup(this);
                birbPopupModal.SetActive(true);
            }
        }
        else
        {
            TryUnlock();
        }
    }

    public bool AddBirbToSlot()
    {
        if (slotBirb != null)
            return false;

        GameObject birbObject = Instantiate(birbPrefab, this.transform, false);
        slotBirb = birbObject.GetComponent<Birb>();
        slotBirb.CreateRandomBirb(fc.cd);

        //fix this, add stuff here

        return true;
    }

    public void AddBirbToCollection()
    {
        ph.AddBirbToAviary(slotBirb);
        slotBirb = null;
    }

    //Check for amount of items being added/subtracted elsewhere making sure it can do the subtraction
    public void AddItems(CollectableItem item)
    {
        slotItems = CollectableItem.Add(slotItems, item);
        if (slotItems.HasItems())
        {
            canAttractBirb = true;
        }
        else
        {
            canAttractBirb = false;
        }
    }

    public void RemoveItems(CollectableItem item)
    {
        if (CollectableItem.HasEnoughResources(slotItems, item))
        {
            slotItems = CollectableItem.Subtract(slotItems, item);
        }
        if (slotItems.HasItems())
        {
            canAttractBirb = true;
        }
        else
        {
            canAttractBirb = false;
        }
    }

    public void DestroyBirb()
    {
        Destroy(slotBirb.gameObject);
    }

    public void ResetTimer()
    {
        //TODO: Add logic for increasing timers for adding more items
        timer = 10f;
    }
}
