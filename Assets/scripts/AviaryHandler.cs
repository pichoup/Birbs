using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryHandler : MonoBehaviour {
    public PlayerBirbInventory pbi;
    public float timer;

	// Use this for initialization
	void Start () {
        pbi = GameObject.FindGameObjectWithTag("PlayerBirbInventory").GetComponent<PlayerBirbInventory>();
	}

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            timer = 0f;
            UpdateAllBirbsInInventory();
        }
    }

    void UpdateAllBirbsInInventory()
    {
        foreach (Birb b in pbi.aviaryBirbs)
        {
            b.TickBirb();
        }
    }
}
