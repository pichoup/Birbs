using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeederSlot : MonoBehaviour {
    public FeederBirb wildBirb;
    public CollectableItem unlockCost;
    public CollectableItem itemsInFeeder;
    public PlayerHandler ph;
    public CrappyDatabase cd;

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
        if (wildBirb == null && unlocked)
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
            if (wildBirb != null)
            {
                //Display You got birb thing here

                ph.AddBirbToCollection(wildBirb);
                wildBirb = null;
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
        wildBirb = birb.GetComponent<FeederBirb>();
        wildBirb.CreateRandomBirb(cd);
    }
}
