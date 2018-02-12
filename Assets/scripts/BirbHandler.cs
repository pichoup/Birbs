using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class BirbHandler<T> : MonoBehaviour where T : Birb {
    public PlayerHandler ph;
    public ModalHandler mh;

    public Transform birbTransform;
    public GameObject birbPrefab;
    public List<T> birbList;

    public bool birbsNeedToTick;
    public float timer;
    public int maxBirbsInThisInventory;
    public int openBirbSlot;

    public virtual void Start()
    {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
        mh = GameObject.FindGameObjectWithTag("ModalHandler").GetComponent<ModalHandler>();
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

    public virtual bool TryAddBirb(Birb birb, Enums.BirbLocation location)
    {
        openBirbSlot = CheckForOpenBirbSlot();
        if (openBirbSlot >= 0)
        {
            Enums.BirbLocation initialLocation = location;

            GameObject go = Instantiate(birbPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(birbTransform.GetChild(FindOpenBirbSlot()));
            go.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            go.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            birbList.Add(go.GetComponent<T>());
            birbList[openBirbSlot].SetBirbStats(birb);
            birbList[openBirbSlot].birbLocation = location;

            //I think I need this
            ph.allPlayerBirbs.Remove(birb);
            ph.allPlayerBirbs.Add(birbList[openBirbSlot]);

            return true;
        }
        return false;
    }

    protected virtual int FindOpenBirbSlot()
    {
        for (int i = 0; i < maxBirbsInThisInventory; i++)
        {
            if (transform.GetChild(i).childCount == 0)
            {
                return i;
            }
        }

        //birbList is empty, return first slot
        return 0;
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

    public virtual void CreateMoveBirbPopup(Birb birb)
    {
        mh.OpenMoveBirbModal(birb.birbLocation, birbList.FindIndex(x => x == birb));
    }

    public virtual void MoveBirbInBirbList(int index, Enums.BirbLocation toLocation)
    {
        birbList[index].MoveBirb(toLocation);
    }

    //public Enums.BirbLocation RemoveBirbFromHandler<T>(T birb, Enums.BirbLocation location) where T : Birb
    //{
    //    switch (location)
    //    {
    //        case Enums.BirbLocation.Aviary:
    //            GameObject.FindGameObjectWithTag("AviaryHandler").GetComponent<AviaryHandler>().birbList.Remove(birb);
    //            return Enums.BirbLocation.Aviary;

    //        case Enums.BirbLocation.NestParent:

    //            return Enums.BirbLocation.NestParent;

    //        default:
    //            Debug.LogError("Something went wrong");
    //            return Enums.BirbLocation.Collection;
    //    }
    
    //}
}
