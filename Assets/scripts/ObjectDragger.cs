using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class ObjectDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public bool dragObject;

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragObject = false;
    }

    public void StartDrag()
    {
        dragObject = true;
    }
}
