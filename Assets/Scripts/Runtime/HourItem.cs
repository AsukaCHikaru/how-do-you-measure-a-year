using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class HourItem : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField] private TextMeshProUGUI hourActionText;
    [SerializeField] internal ActionItem actionItem;
    [SerializeField] internal Image hourIndicator;

    private Color textColor;

    void Start () {
        
    }

    public void SetActionItem (ActionItem item) {
        actionItem = item;
        hourActionText.text = item.actionObject.name;
        textColor = item.actionObject.backgroundColor;
        hourActionText.color = textColor;
    }

    public void OnDrop(PointerEventData eventData) {
        string dropActionName = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<ActionItem>().actionObject.name;
        ActionItem originAction = GameObject.Find("ActionContainer").transform.Find(dropActionName + "Action").GetComponent<ActionItem>();
        SetActionItem(originAction);
        if (dropActionName == "Work") {
            int dropActionId = GameObject.Find("DragItem").transform.GetChild(0).gameObject.GetComponent<ActionItem>().actionObject.id;
            HourController.Instance.ChangeJob(dropActionId);
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        hourActionText.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData) {
        hourActionText.color = textColor;
    }
}
