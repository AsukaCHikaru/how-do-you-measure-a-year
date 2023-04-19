using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HourItem : MonoBehaviour, IDropHandler {
    [SerializeField] private TextMeshProUGUI hourActionText;
    private ActionItem actionItem;

    public void OnDrop(PointerEventData eventData) {
        ActionItem dragItemAction = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<ActionItem>();
        actionItem = dragItemAction;
        hourActionText.text = actionItem.actionObject.name;
    }
}
