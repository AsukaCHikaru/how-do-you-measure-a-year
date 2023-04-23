using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ActionItem : MonoBehaviour
{
    [SerializeField] public ActionObject actionObject;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private SpriteRenderer sprite;

    void Start () {
        titleText.text = actionObject.name;
        descriptionText.text = actionObject.description;
        sprite.color = actionObject.backgroundColor;
    }

    internal void Perform (int performTime) {
        ResourceController.Instance.saveResource.Manipulate(actionObject.saveResourceDifferenceList[performTime]);
        ResourceController.Instance.healthResource.Manipulate(actionObject.healthResourceDifferenceList[performTime]);
        ResourceController.Instance.mentalResource.Manipulate(actionObject.mentalResourceDifferenceList[performTime]);
    }
}
