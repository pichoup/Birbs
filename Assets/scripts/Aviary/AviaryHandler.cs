using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaryHandler : MonoBehaviour {
    public List<AviaryBirb> aviaryBirbs;

    public PlayerHandler ph;
    public float timer;
    public float aviaryTickRate = 1f;

	// Use this for initialization
	void Start () {
        ph = GameObject.FindGameObjectWithTag("PlayerHandler").GetComponent<PlayerHandler>();
	}

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > aviaryTickRate)
        {
            timer = 0f;
            UpdateAllBirbsInInventory();
        }
    }

    void UpdateAllBirbsInInventory()
    {
        foreach (AviaryBirb b in aviaryBirbs)
        {
            b.TickBirb();
        }
    }
}
