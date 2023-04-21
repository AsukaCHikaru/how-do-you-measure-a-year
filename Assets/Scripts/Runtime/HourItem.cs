using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HourItem : MonoBehaviour, IDropHandler {
    [SerializeField] private TextMeshProUGUI hourActionText;
    [SerializeField] internal ActionItem actionItem;

    void Start () {
        hourActionText.text = actionItem.actionObject.name;
    }

    public void OnDrop(PointerEventData eventData) {
        ActionItem dragItemAction = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<ActionItem>();
        actionItem = dragItemAction;
        hourActionText.text = actionItem.actionObject.name;
    }

    internal void PerformAction () {
        actionItem.Perform();
    }
}
