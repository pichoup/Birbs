using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour {
    public List<Birb> birbs;
    public Transform collection;
    public Text resources;

    public CollectableItem totalCollectableItems;
    public CollectableItem collectablesPerSecond;

    private float timer;

    private void Start()
    {
        birbs = new List<Birb>();
        UpdateDisplay();
    }

    private void RecalculateCollectablesPerSecond()
    {
        collectablesPerSecond = new CollectableItem();

        foreach (Birb b in birbs)
        {
            collectablesPerSecond.seeds += b.birbStats.collectAmount.seeds;
            collectablesPerSecond.worms += b.birbStats.collectAmount.worms;
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

    public void AddBirbToCollection(Birb birb)
    {
        birb.transform.SetParent(collection);
        birbs.Add(birb);
        RecalculateCollectablesPerSecond();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resources.text = "Seeds: " + totalCollectableItems.seeds + "\nWorms: " + totalCollectableItems.worms;
    }
}
