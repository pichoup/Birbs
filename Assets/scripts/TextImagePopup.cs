using UnityEngine;

[System.Serializable]
public class TextImagePopup {
    public string text;
    public Sprite image;
    public int amount;

    public TextImagePopup(string tipText, Sprite tipImage, int tipAmount)
    {
        text = tipText;
        image = tipImage;
        amount = tipAmount;
    }
}
