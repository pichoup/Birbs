using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {
    public List<Birb> allPlayerBirbs;

    public AviaryHandler ah;
    public BreedingHandler bh;
    public ChildEggHandler ceh;
    public CollectionHandler ch;
    public HatchingHandler hh;

    public CollectableItem collectableItems;

    public float defaultTickRate;

    private void Start()
    {
        collectableItems = new CollectableItem();
    }
}
