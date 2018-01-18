using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryHandler : MonoBehaviour {
    public PlayerBirbInventory pbi;

	// Use this for initialization
	void Start () {
        pbi = GameObject.FindGameObjectWithTag("PlayerBirbInventory").GetComponent<PlayerBirbInventory>();
	}

    private void Update()
    {
        UpdateAllBirbsInInventory();
    }

    void UpdateAllBirbsInInventory()
    {
        foreach (Birb b in pbi.aviaryBirbs)
        {

        }
    }
}
