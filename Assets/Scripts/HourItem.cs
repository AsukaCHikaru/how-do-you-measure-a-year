using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HourItem : MonoBehaviour, IDropHandler {
    [SerializeField] private TextMeshProUGUI hourActionText;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log(eventData);
        DraggableActionItem dragItem = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<DraggableActionItem>();
    }
}
