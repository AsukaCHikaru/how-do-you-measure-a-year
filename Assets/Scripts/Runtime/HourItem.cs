using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HourItem : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private TextMeshProUGUI hourActionText;
    [SerializeField] internal ActionItem actionItem;

    void Start () {
        
    }

    public void SetActionItem (ActionItem item) {
        actionItem = item;
        hourActionText.text = item.actionObject.name;
    }

    public void OnDrop(PointerEventData eventData) {
        ActionItem dragItemAction = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<ActionItem>();
        SetActionItem(dragItemAction);
    }

    internal void PerformAction () {
        actionItem.Perform();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hourActionText.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hourActionText.color = Color.white;
    }
}
