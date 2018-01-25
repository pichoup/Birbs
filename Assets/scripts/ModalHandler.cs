using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalHandler : MonoBehaviour {
    public List<Sprite> popupSprites;
    public List<TextImagePopup> popups;

    public GameObject popupPrefab;
    public GameObject popupParent;

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
            GameObject go = Instantiate(popupPrefab, popupParent.transform, false);
            go.transform.GetChild(1).GetComponent<Image>().sprite = p.image;
            go.transform.GetChild(2).GetComponent<Text>().text = "You Got " + p.amount + " " + p.text;
        }
        popups.Clear();
    }
}
