using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public abstract class BirbHandler<T> : MonoBehaviour where T : Birb {
    public PlayerHandler ph;
    public ModalHandler mh;

    public Enums.BirbLocation handlerLocation;

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
        birbList = new List<T>();

        Type type = typeof(T);
        //for (int i = 0; i < ph.allPlayerBirbs.Count; i++)
        //{
        //    if (ph.allPlayerBirbs[i].birbLocation == GetLocationFromBirbType(type))
        //    {
        //        TryAddBirb(ph.allPlayerBirbs[i], ph.allPlayerBirbs[i].birbLocation);
        //        Destroy(ph.allPlayerBirbs[i].gameObject);
        //    }
        //}
    }

    private void Update()
    {
        if (birbsNeedToTick)
        {
            timer += Time.deltaTime;
            //if (timer > ph.defaultTickRate)
            //{
            //    timer = 0f;
            //    UpdateBirbs(birbList, ph.defaultTickRate);
            //}
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
        switch (location)
        {
            case Enums.BirbLocation.Aviary:
                if (!birb.hatched)
                    return false;
                break;

            case Enums.BirbLocation.NestParent:
                if (!birb.hatched)
                    return false;
                break;

            default:
                break;
        }

        openBirbSlot = CheckForOpenBirbSlot();
        if (openBirbSlot >= 0)
        {
            GameObject go = Instantiate(birbPrefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(birbTransform.GetChild(FindOpenBirbSlot()));
            go.GetComponent<RectTransform>().offsetMax = Vector2.zero;
            go.GetComponent<RectTransform>().offsetMin = Vector2.zero;
            birbList.Add(go.GetComponent<T>());
            birbList[openBirbSlot].SetBirbStats(birb);
            birbList[openBirbSlot].birbLocation = location;
            return true;
        }
        return false;
    }

    private int FindOpenBirbSlot()
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

    private Enums.BirbLocation GetLocationFromBirbType(Type type)
    {
        if (type == typeof(AviaryBirb))
        {
            return Enums.BirbLocation.Aviary;
        }
        if (type == typeof(BreedingBirb))
        {
            return Enums.BirbLocation.NestParent;
        }
        if (type == typeof(ChildEggBirb))
        {
            return Enums.BirbLocation.NestParentsEgg;
        }
        if (type == typeof(CollectionBirb))
        {
            return Enums.BirbLocation.Collection;
        }
        if (type == typeof(HatchingBirb))
        {
            return Enums.BirbLocation.NestHatching;
        }

        Debug.LogError("Something Went Wrong");
        return Enums.BirbLocation.Collection;
    }
}
