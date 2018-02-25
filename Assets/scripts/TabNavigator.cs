using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabNavigator : MonoBehaviour {
    public List<RectTransform> tabs;

    public void NavigateToTab(string tab)
    {
        foreach (RectTransform t in tabs)
        {
            if (t.name.Equals(tab))
            {
                t.offsetMin = Vector2.zero;
                t.offsetMax = Vector2.zero;
            }
            else
            {
                t.offsetMin = new Vector2(3000f, 0f);
                t.offsetMax = new Vector2(3000f, 0f);
            }
        }
    }
}
