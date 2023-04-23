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

    internal void Perform () {
        ResourceController.Instance.saveResource.Manipulate(actionObject.saveResourceDifference);
        ResourceController.Instance.healthResource.Manipulate(actionObject.healthResourceDifference);
        ResourceController.Instance.mentalResource.Manipulate(actionObject.mentalResourceDifference);
    }
}
