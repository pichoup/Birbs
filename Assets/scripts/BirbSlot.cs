using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirbSlot : MonoBehaviour {
    public Birb slotBirb;
    public CollectableItem unlockCost;
    public PlayerHandler ph;
    public CrappyDatabase cd;

    public GameObject birbPopupModal;

    public GameObject birbPrefab;

    private float timer = 2f;
    private bool unlocked;

    private void Start()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        cd = GameObject.Find("CrappyDatabase").GetComponent<CrappyDatabase>();
    }

    private void Update()
    {
        if (slotBirb == null && unlocked)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = Random.Range(5f, 20f);
                GenerateNewBirb();
            }
        }
    }
    private void TryUnlock()
    {
        if (ph.totalCollectableItems.seeds >= unlockCost.seeds && ph.totalCollectableItems.worms >= unlockCost.worms)
        {
            unlocked = true;
            ph.totalCollectableItems.seeds -= unlockCost.seeds;
            ph.totalCollectableItems.worms -= unlockCost.worms;
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

    private void GenerateNewBirb()
    {
        GameObject birb = Instantiate(birbPrefab, this.transform, false);
        slotBirb = birb.GetComponent<Birb>();
        slotBirb.CreateRandomBirb(cd);
    }

    public void AddBirbToCollection()
    {
        ph.AddBirbToCollection(slotBirb);
        slotBirb = null;
    }

    public void DestroyBirb()
    {
        Destroy(slotBirb.gameObject);
    }
}
