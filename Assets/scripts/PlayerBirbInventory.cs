using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBirbInventory : MonoBehaviour {
    public List<Birb> collectionBirbs;
    public List<Birb> aviaryBirbs;

    public int collectionSize;
    public int aviarySize;

    private void Start()
    {
        collectionBirbs = new List<Birb>();
        aviaryBirbs = new List<Birb>();
    }

    public void AddBirbFromOneInventoryToAnother(Birb birb, List<Birb> from, Enums.BirbLocation to)
    {
        if (birb.birbLocation == to) return;

        switch (to)
        {
            case Enums.BirbLocation.Aviary:
                if (aviaryBirbs.Count < aviarySize)
                {
                    bool removed = from.Remove(birb);
                    if (!removed)
                        Debug.LogError("object did not exist in from list, we probably just duplicated a birb");
                    aviaryBirbs.Add(birb);
                }
                else
                {
                    Debug.Log("Aviary is Full!");
                }
                break;

            case Enums.BirbLocation.Collection:
                if (collectionBirbs.Count < collectionSize)
                {
                    bool removed = from.Remove(birb);
                    if (!removed)
                        Debug.LogError("object did not exist in from list, we probably just duplicated a birb");
                    collectionBirbs.Add(birb);
                }
                else
                {
                    Debug.Log("Collection is Full!");
                }
                break;

            default:
                Debug.Log("Past Danny you probably suck at coding");
                break;
        }

        

        //refresh screens somewhere here
    }
}
