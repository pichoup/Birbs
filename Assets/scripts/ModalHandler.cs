using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalHandler : MonoBehaviour {
    public List<Sprite> popupSprites;
    public List<TextImagePopup> popups;

    public Transform popupParent;

    public GameObject popupPrefab;
    public GameObject moveBirbPrefab;
    public GameObject moveBirbModal;

    private void Start()
    {
        popups = new List<TextImagePopup>();
    }

    public void AddPopupToList(string type, int spriteType, int amount)
    {
        popups.Add(new TextImagePopup(type, popupSprites[spriteType], amount));
    }

    public void ShowPopups()
    {
        foreach (TextImagePopup p in popups)
        {
            GameObject go = Instantiate(popupPrefab, popupParent, false);
            go.transform.GetChild(1).GetComponent<Image>().sprite = p.image;
            go.transform.GetChild(2).GetComponent<Text>().text = "You Got " + p.amount + " " + p.text;
        }
        popups.Clear();
    }

    public void OpenMoveBirbModal(Enums.BirbLocation location, int birbIndex)
    {
        if (moveBirbModal == null)
        {
            moveBirbModal = Instantiate(moveBirbPrefab, popupParent, false);
            moveBirbModal.GetComponent<BirbMover>().index = birbIndex;
            moveBirbModal.GetComponent<BirbMover>().currentLocation = location;
        }
    }
}
