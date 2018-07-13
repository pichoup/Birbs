using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour {
    public List<Birb> birbs;
    public Transform collection;
    public RectTransform aviary;
    public Text resources;

    public GameObject aviaryBirbPrefab;
    public BirbStatsPopup statsPopup;

    public CollectableItem totalCollectableItems { get; private set; }
    public CollectableItem collectablesPerSecond;

    private float timer;

    private void Start()
    {
        birbs = new List<Birb>();
        totalCollectableItems = new CollectableItem(20, 20);
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

    //private void Update()
    //{
    //    timer -= Time.deltaTime;
    //    if (timer <= 0f)
    //    {
    //        timer = 1f;
    //        totalCollectableItems.seeds += collectablesPerSecond.seeds;
    //        totalCollectableItems.worms += collectablesPerSecond.worms;
    //        UpdateDisplay();
    //    }
    //}

    public void AddBirbToCollection(Birb birb)
    {
        birb.transform.SetParent(collection);
        birbs.Add(birb);
        //RecalculateCollectablesPerSecond();
        UpdateDisplay();
    }

    public void AddBirbToAviary(Birb birb)
    {
        Vector3 position = GetEmptyPositionInsideRect(aviary);
        Birb b = Instantiate(aviaryBirbPrefab, position, Quaternion.identity, aviary).GetComponent<Birb>();
        b.SetBirbStats(birb);
        b.isWildBirb = false;
        Destroy(birb.gameObject);
        birbs.Add(b);
        //RecalculateCollectablesPerSecond();
        UpdateDisplay();
    }

    public void AddResources(CollectableItem amount)
    {
        totalCollectableItems = CollectableItem.Add(totalCollectableItems, amount);
        UpdateDisplay();
    }

    public void SubtractResources(CollectableItem amount)
    {
        totalCollectableItems = CollectableItem.Subtract(totalCollectableItems, amount);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resources.text = "Seeds: " + totalCollectableItems.seeds + "\nWorms: " + totalCollectableItems.worms;
    }

    private Vector3 GetEmptyPositionInsideRect(RectTransform rect)
    {
        //TODO: do something better to find free space inside the rect later
        Vector3[] corners = new Vector3[4];
        rect.GetWorldCorners(corners);

        return (new Vector3((corners[2].x - corners[0].x) / 2f + corners[0].x, (corners[2].y - corners[0].y) / 2f + corners[0].y, 0f));  
    }

    public void CheckStats(Birb birb)
    {
        statsPopup.PopulatePopup(birb);
        statsPopup.gameObject.SetActive(birb);
    }
}
