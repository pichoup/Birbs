using UnityEngine.EventSystems;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ObjectDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public bool dragObject;
    public ScrollRect sr;

    private float pointerPosition;
    private Vector2 pos;
    private bool posSet = false;

    void Start()
    {
        sr = GameObject.FindGameObjectWithTag("MainGameView").GetComponent<ScrollRect>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject)
        {
            pointerPosition = eventData.position.x / Screen.width;
            pos = eventData.position;
            posSet = true;

            //not sure if this will make the position get set twice
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragObject = false;
        posSet = false;
    }

    public void StartDrag()
    {
        dragObject = true;
    }

    void Update()
    {
        if (posSet)
        {
            if (pointerPosition <= 0.1f)
            {
                sr.horizontalNormalizedPosition -= Time.deltaTime;
            }
            else if (pointerPosition >= 0.9f)
            {
                sr.horizontalNormalizedPosition += Time.deltaTime;
            }
            transform.position = pos;
        }
    }
}
