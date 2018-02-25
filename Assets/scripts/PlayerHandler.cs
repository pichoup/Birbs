using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour {
    public List<FeederBirb> birbs;
    public Transform collection;
    public Text resources;

    public CollectableItem totalCollectableItems;
    public CollectableItem collectablesPerSecond;

    private float timer;

    private void Start()
    {
        birbs = new List<FeederBirb>();
        UpdateDisplay();
    }

    private void RecalculateCollectablesPerSecond()
    {
        collectablesPerSecond = new CollectableItem();

        foreach (FeederBirb b in birbs)
        {
            collectablesPerSecond.seeds += b.collectAmount.seeds;
            collectablesPerSecond.worms += b.collectAmount.worms;
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1f;
            totalCollectableItems.seeds += collectablesPerSecond.seeds;
            totalCollectableItems.worms += collectablesPerSecond.worms;
            UpdateDisplay();
        }
    }

    public void AddBirbToCollection(FeederBirb birb)
    {
        birb.transform.SetParent(collection);
        birbs.Add(birb);
        RecalculateCollectablesPerSecond();
    }

    private void UpdateDisplay()
    {
        resources.text = "Seeds: " + totalCollectableItems.seeds + "\nWorms: " + totalCollectableItems.worms;
    }
}
