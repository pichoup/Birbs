using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbMover : MonoBehaviour {
    public Enums.BirbLocation currentLocation;
    public int index;

    public void MoveBirbAndCloseModal(GetEnum ge)
    {
        //TODO: come up with a better system for all popups
        switch (currentLocation)
        {
            case Enums.BirbLocation.Aviary:
                GameObject.FindGameObjectWithTag("AviaryHandler").GetComponent<AviaryHandler>().MoveBirbInBirbList(index, ge.state);
                break;

            case Enums.BirbLocation.NestParent:
                GameObject.FindGameObjectWithTag("BreedingHandler").GetComponent<BreedingHandler>().MoveBirbInBirbList(index, ge.state);
                break;

            case Enums.BirbLocation.Collection:
                GameObject.FindGameObjectWithTag("CollectionHandler").GetComponent<CollectionHandler>().MoveBirbInBirbList(index, ge.state);
                break;

            case Enums.BirbLocation.NestHatching:
                GameObject.FindGameObjectWithTag("HatchingHandler").GetComponent<HatchingHandler>().MoveBirbInBirbList(index, ge.state);
                break;

            default:
                Debug.Log("Something went wrong");
                break;
        }

        Destroy(this.gameObject);
    }
}
