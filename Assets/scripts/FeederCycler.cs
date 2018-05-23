using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeederCycler : MonoBehaviour {
    public List<Birb> wildBirbs;
    public PlayerHandler ph;
    public CrappyDatabase cd;

    private BirbSlot[] birbSlots;
    private int wildBirbSize;

	// Use this for initialization
	void Start () {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        cd = GameObject.Find("CrappyDatabase").GetComponent<CrappyDatabase>();

        wildBirbs = new List<Birb>();
        birbSlots = transform.GetComponentsInChildren<BirbSlot>();

        UpdateBirbSlots();
    }

    private void Update()
    {
        foreach (BirbSlot bs in birbSlots)
        {
            if (bs.slotBirb == null && bs.unlocked)
            {
                bs.timer -= Time.deltaTime;
                if (bs.timer <= 0f)
                {
                    bs.ResetTimer();
                    TryAddBirbForBirbSlot(bs);
                }
            }
        }
    }

    private void GenerateNewBirbForSlot(BirbSlot slot)
    {
        //List<Birb> spawnableBirbs = new List<Birb>();

        ////add all birbs that can spawn into a list
        //foreach (Birb b in wildBirbs)
        //{
        //    if (CollectableItem.HasEnoughResources(slot.slotItems, b.birbStats.minimumFeederAmount))
        //    {
        //        spawnableBirbs.Add(b);
        //    }  
        //}

        ////pick a random birb to spawn from list
        //int rand = Random.Range(0, spawnableBirbs.Count - 1);

        slot.AddBirbToSlot();

    }

    public void UpdateBirbSlots()
    {
        wildBirbSize = 0;
        foreach (BirbSlot bs in birbSlots)
        {
            wildBirbSize = bs.unlocked ? wildBirbSize + 1 : wildBirbSize;
        }
        wildBirbSize *= 10;
    }

    private void TryAddBirbForBirbSlot(BirbSlot bs)
    {
        if (Random.value >= 0.0f && wildBirbs.Count < wildBirbSize)
        {
            GenerateNewBirbForSlot(bs);
        }
        else
        {
            //find all birbs that meet requirements here
        }
    }
}
