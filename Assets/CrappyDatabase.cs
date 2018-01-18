using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class CrappyDatabase : MonoBehaviour {

    //holds all the species of birbs for now
    public List<BirbSpecies> allBirbs = new List<BirbSpecies>();

    public BirbSpecies GetSpeciesById(int id)
    {
        return allBirbs.FirstOrDefault(a => a.id == id);
    }
}
