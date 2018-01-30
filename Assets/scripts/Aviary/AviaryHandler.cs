using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryHandler : MonoBehaviour {
    public List<AviaryBirb> aviaryBirbs;
    public int maxBirbsInAviary;

    public PlayerHandler ph;
    public ModalHandler mh;

    private float timer;

    public float aviaryTickRate = 1f;

	// Use this for initialization
	void Start () {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        mh = GameObject.FindGameObjectWithTag("ModalHandler").GetComponent<ModalHandler>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > aviaryTickRate)
        {
            timer = 0f;
            UpdateAllBirbsInInventory();
        }
    }

    private void UpdateAllBirbsInInventory()
    {
        foreach (AviaryBirb b in aviaryBirbs)
        {
            b.TickBirb();
        }
    }

    public bool AddBirb(Birb birb)
    {
        if (aviaryBirbs.Count < maxBirbsInAviary)
        {
            AviaryBirb ab = new AviaryBirb();
            aviaryBirbs.Add(ab);
            return true;
        }
        return false;
    }

    public void AddBirbDropsToInventory(CollectableItem ci)
    {
        bool aBirbCollectedStuff = false;

        //make collectable items a list or something in the future
        if (ci.seeds > 0)
        {
            ph.collectableItems.seeds += ci.seeds;
            mh.AddPopupToList("seeds", 0, ci.seeds);
            ci.seeds = 0;
            aBirbCollectedStuff = true;
        }

        if (ci.worms > 0)
        {
            ph.collectableItems.worms += ci.worms;
            mh.AddPopupToList("worms", 1, ci.worms);
            ci.worms = 0;
            aBirbCollectedStuff = true;
        }

        if (aBirbCollectedStuff)
        {
            mh.ShowPopups();
        }
    }

}
