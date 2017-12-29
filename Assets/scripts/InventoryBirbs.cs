using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryBirbs : MonoBehaviour {
    //public GameObject feederBirb;
    //public List<Birb> birbList;
    //public NestBirb nestBirb;
    //public IncubationBirb incubationBirb;

    //public Transform contentPanel;
    //public Transform nest;
    //public Transform incubator;
    //public Transform feeder;
    //public SimpleObjectPool buttonObjectPool;

    //public float timer = 2f;

    //// Use this for initialization
    //void Start()
    //{
    //    RefreshDisplay();
    //}

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //    timer -= Time.deltaTime;
    //    if (timer <= 0f)
    //    {
    //        timer = 5f;
    //        MakeNewBirb();
    //    }
    //}

    //public void MakeNewBirb(bool egg = false, List<Birb> parentbBirbs = null)
    //{
    //    if (!egg)
    //    {
    //        bool noBirb = false;
    //        GameObject[] birbs = GameObject.FindGameObjectsWithTag("birb");
    //        foreach (GameObject b in birbs)
    //        {
    //            if (b.GetComponent<Birb>().location == 3)
    //                noBirb = true;
    //        }
    //        if (!noBirb)
    //        {
    //            GameObject birb = Instantiate(feederBirb);
    //            birb.transform.SetParent(feeder.GetChild(0).transform);
    //            birb.GetComponent<Birb>().location = 3;
    //            birb.GetComponent<Birb>().SetColor();
    //            birb.GetComponent<SampleButton>().Setup(birb.GetComponent<Birb>(), this);
    //        }
    //    }
    //    else {
    //        bool noBirb = false;
    //        GameObject[] birbs = GameObject.FindGameObjectsWithTag("birb");
    //        foreach (GameObject b in birbs)
    //        {
    //            if (b.GetComponent<Birb>().location == 2)
    //                noBirb = true;
    //        }
    //        if (!noBirb)
    //        {
    //            GameObject birb = Instantiate(feederBirb);
    //            birb.transform.SetParent(incubator.GetChild(0).transform);
    //            birb.GetComponent<Birb>().location = 2;
    //            birb.GetComponent<Birb>().SetParent(parentbBirbs);
    //            birb.GetComponent<Birb>().SetColor();
    //            birb.GetComponent<SampleButton>().Setup(birb.GetComponent<Birb>(), this);
    //            AddBirb(birb.GetComponent<Birb>(), birb.GetComponent<Birb>().location);
    //        }
    //    }
    //}

    //void RefreshDisplay()
    //{
    //    RemoveButtons();
    //    AddButtons();
    //}

    //private void RemoveButtons()
    //{
    //    while (contentPanel.childCount > 0)
    //    {
    //        GameObject toRemove = transform.GetChild(0).gameObject;
    //        buttonObjectPool.ReturnObject(toRemove);
    //    }
    //}

    //private void AddButtons()
    //{
    //    for (int i = 0; i < birbList.Count; i++)
    //    {
    //        Birb birb = birbList[i];
    //        GameObject newButton = buttonObjectPool.GetObject();
    //        newButton.transform.SetParent(contentPanel);

    //        SampleButton sampleButton = newButton.GetComponent<SampleButton>();
    //        sampleButton.Setup(birb, this);
    //    }
    //}

    //public void TryTransferBirbToOtherArea(Birb birb)
    //{
    //    int loc = birb.location;
    //    if (loc == 0)
    //    {
    //        if (nestBirb.nestList.Count == 0)
    //        {
    //            RemoveBirb(birb, 0);
    //            AddBirb(birb, 1);
    //            birb.location = 1;
    //            birb.transform.SetParent(GameObject.Find("Nest").transform.GetChild(0).transform);
    //        }
    //        else if (nestBirb.nestList.Count == 1)
    //        {
    //            RemoveBirb(birb, 0);
    //            AddBirb(birb, 1);
    //            birb.location = 1;
    //            if (GameObject.Find("Nest").transform.GetChild(0).childCount == 0)
    //                birb.transform.SetParent(GameObject.Find("Nest").transform.GetChild(0).transform);
    //            else
    //                birb.transform.SetParent(GameObject.Find("Nest").transform.GetChild(1).transform);
    //        }
    //    }
    //    else if (loc == 1)
    //    {
    //        AddBirb(birb, 0);
    //        RemoveBirb(birb, loc);
    //        birb.location = 0;
    //    }
    //    else if (loc == 2)
    //    {
    //        AddBirb(birb, 0);
    //        RemoveBirb(birb, loc);
    //        birb.location = 0;
    //    }
    //    else if (loc == 3)
    //    {
    //        AddBirb(birb, 0);
    //        RemoveBirb(birb, loc);
    //        birb.location = 0;
    //        birb.transform.SetParent(contentPanel);
    //    }
    //    Debug.Log("attempted");
    //}

    //void AddBirb(Birb birbToAdd, int locationToAddBirb)
    //{
    //    //nest or incubator
    //    if (locationToAddBirb == 0)
    //    {
    //        birbList.Add(birbToAdd);
    //    }
    //    else if (locationToAddBirb == 1)
    //    {
    //        nestBirb.nestList.Add(birbToAdd);
    //    }
    //    else if (locationToAddBirb == 2)
    //    {
    //        incubationBirb.incubationList.Add(birbToAdd);
    //    }
    //}

    //private void RemoveBirb(Birb birbToRemove, int location)
    //{
    //    if (location == 0)
    //    {
    //        for (int i = birbList.Count - 1; i >= 0; i--)
    //        {
    //            if (birbList[i] == birbToRemove)
    //            {
    //                birbList.RemoveAt(i);
    //            }
    //        }
    //    }
    //    else if (location == 1)
    //    {
    //        for (int i = nestBirb.nestList.Count - 1; i >= 0; i--)
    //        {
    //            if (nestBirb.nestList[i] == birbToRemove)
    //            {
    //                birbToRemove.transform.SetParent(contentPanel);
    //                nestBirb.nestList.RemoveAt(i);
    //            }
    //        }
    //    }
    //    else if (location == 2)
    //    {
    //        for (int i = incubationBirb.incubationList.Count - 1; i >= 0; i--)
    //        {
    //            if (incubationBirb.incubationList[i] == birbToRemove)
    //            {
    //                birbToRemove.transform.SetParent(contentPanel);
    //                incubationBirb.incubationList.RemoveAt(i);
    //            }
    //        }
    //    }
    //}
}
