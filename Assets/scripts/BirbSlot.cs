using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbSlot : MonoBehaviour {
    public Birb slotBirb;
    public CollectableItem unlockCost;
    public CollectableItem slotCost;
    public CollectableItem slotItems;
    public PlayerHandler ph;
    public FeederCycler fc;

    public GameObject birbPopupModal;
    public GameObject birbPrefab;

    public float timer = 2f;
    public bool unlocked;
    public bool canAttractBirb;

    public bool firstBirb = true;

    private void Start()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        fc = transform.parent.GetComponent<FeederCycler>();
    }

    private void TryUnlock()
    {
        if (CollectableItem.HasEnoughResources(ph.totalCollectableItems, unlockCost))
        {
            ph.SubtractResources(unlockCost);
            unlocked = true;
            fc.UpdateBirbSlots();
            transform.GetChild(0).GetComponent<Text>().text = "Please add " + slotCost.seeds + " seeds and " + slotCost.worms + " worms";
        }
    }

    private void TryAddResourcesToSlot()
    {
        if (CollectableItem.HasEnoughResources(ph.totalCollectableItems, slotCost))
        {
            ph.SubtractResources(slotCost);
            canAttractBirb = true;
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
            else
            {
                if (!canAttractBirb)
                {
                    TryAddResourcesToSlot();
                }
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
        slotBirb.CreateRandomBirb(fc.cd, true, null, firstBirb);
        firstBirb = false;

        //fix this, add stuff here

        return true;
    }

    //adding a birb means deleting this one, and making it open again to add more seeds
    public void AddBirbToCollection()
    {
        transform.GetChild(0).GetComponent<Text>().text = "Please add " + slotCost.seeds + " seeds and " + slotCost.worms + " worms";
        transform.GetChild(0).GetComponent<Text>().enabled = true;
        canAttractBirb = false;
        ph.AddBirbToAviary(slotBirb);
        slotBirb = null;
    }

    ////Check for amount of items being added/subtracted elsewhere making sure it can do the subtraction
    //public void AddItems(CollectableItem item)
    //{
    //    slotItems = CollectableItem.Add(slotItems, item);
    //    if (slotItems.HasItems())
    //    {
    //        canAttractBirb = true;
    //    }
    //    else
    //    {
    //        canAttractBirb = false;
    //    }
    //}

    //public void RemoveItems(CollectableItem item)
    //{
    //    if (CollectableItem.HasEnoughResources(slotItems, item))
    //    {
    //        slotItems = CollectableItem.Subtract(slotItems, item);
    //    }
    //    if (slotItems.HasItems())
    //    {
    //        canAttractBirb = true;
    //    }
    //    else
    //    {
    //        canAttractBirb = false;
    //    }
    //}

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
