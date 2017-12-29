using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BirbColors
{
    public Color head;
    public Color body;
    public Color tail;
    public Color wings;

    //high - common, low - rare
    public int colorRarity;

    public BirbColors MutateColors(BirbColors color)
    {
        color.head = MixColors(color.head);
        color.body = MixColors(color.body);
        color.tail = MixColors(color.tail);
        color.wings = MixColors(color.wings);
        return color;
    }

    private Color MixColors(Color c)
    {
        float r = Mathf.Clamp01(c.r + Random.Range(-0.2f, 0.2f));
        float g = Mathf.Clamp01(c.g + Random.Range(-0.2f, 0.2f));
        float b = Mathf.Clamp01(c.b + Random.Range(-0.2f, 0.2f));
        return new Color(r, g, b);
    }
}
