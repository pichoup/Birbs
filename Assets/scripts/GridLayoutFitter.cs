using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutFitter : MonoBehaviour {

    private GridLayoutGroup gridLayoutGroup;
    private RectTransform rect;
    private float width;
    private int cellCount;

    void Start()
    {
        //we want to take up ~90% of screen width
        width = Screen.width * 0.9f;
        
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        int paddingSum = gridLayoutGroup.padding.left + gridLayoutGroup.padding.right;
        float totalMiddleSpacing = (gridLayoutGroup.constraintCount - 1) * paddingSum / 2f;
        float gridSpace = (width - totalMiddleSpacing - paddingSum) / gridLayoutGroup.constraintCount;

        gridLayoutGroup.cellSize = new Vector2(gridSpace, gridSpace);
    }
}
