using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {
    public List<Birb> allPlayerBirbs;

    public CollectableItem collectableItems;

    public float defaultTickRate;

    private void Start()
    {
        //allPlayerBirbs = new List<Birb>();
        collectableItems = new CollectableItem();
    }
}
