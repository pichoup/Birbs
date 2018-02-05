using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BirbHandler<T> : MonoBehaviour where T : Birb {
    public PlayerHandler ph;
    public Transform birbTransform;
    public GameObject birbPrefab;
    public List<T> birbList;

    public bool birbsNeedToTick;
    public float timer;
    public int maxBirbsInThisInventory;
    public int openBirbSlot;

    private void Start()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
    }

    private void Update()
    {
        if (birbsNeedToTick)
        {
            timer += Time.deltaTime;
            if (timer > ph.defaultTickRate)
            {
                timer = 0f;
                UpdateBirbs(birbList, ph.defaultTickRate);
            }
        }
    }

    public virtual void UpdateBirbs(List<T> birbList, float time = 0f)
    {
        foreach (Birb b in birbList)
        {
            b.TickBirb(time);
        }
    }

    public virtual bool TryAddBirb(Birb birb)
    {
        openBirbSlot = CheckForOpenBirbSlot();
        if (openBirbSlot >= 0)
        {
            GameObject go = Instantiate(birbPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(birbTransform.GetChild(openBirbSlot));
            go.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            go.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            birbList[openBirbSlot] = go.GetComponent<T>();
            birbList[openBirbSlot].SetBirbStats(birb);
            return true;
        }
        return false;
    }

    protected virtual int CheckForOpenBirbSlot()
    {
        if (birbList.Count < maxBirbsInThisInventory)
        {
            return birbList.Count;
        }
        return -1;
    }

    protected virtual int GetMaxBirbsForThisInventory()
    {
        return birbTransform.childCount;
    }
}
