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
        string dropActionName = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<ActionItem>().actionObject.name;
        ActionItem originAction = GameObject.Find("ActionContainer").transform.Find(dropActionName + "Action").GetComponent<ActionItem>();
        SetActionItem(originAction);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hourActionText.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hourActionText.color = Color.white;
    }
}
