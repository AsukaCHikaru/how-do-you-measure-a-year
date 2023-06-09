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
    public int allTimePerformTime = 0;

    void Start () {
        SetupUI();
    }

    internal void Perform (int performTime) {
        allTimePerformTime += 1;
        ResourceController.Instance.saveResource.Manipulate(actionObject.saveResourceDifferenceList[performTime]);
        ResourceController.Instance.healthResource.Manipulate(actionObject.healthResourceDifferenceList[performTime]);
        ResourceController.Instance.mentalResource.Manipulate(actionObject.mentalResourceDifferenceList[performTime]);
        ResourceController.Instance.knowledgeResource.Manipulate(actionObject.knowledgeResourceDifferenceList[performTime]);

        if (actionObject.name == "Job Hunt") {
            Debug.Log("job hunt");
            WorkActionController.Instance.RollJobHunt();
        }

        if (actionObject.name == "Quit") {
            int workId = -1;
            foreach(HourItem hour in HourController.Instance.hourItemList) {
                string actionName = hour.actionItem.actionObject.name;
                if (actionName == "Work" || actionName == "Quit") {
                    if (actionName == "Work") {
                        workId = hour.actionItem.actionObject.id;
                    }
                    hour.SetActionItem(GameObject.Find("IdleAction").GetComponent<ActionItem>());
                }
            }
           
            WorkActionController.Instance.QuitWork(workId);
        }
    }

    internal void SetupActionObject (ActionObject newObject) {
        actionObject = newObject;
        SetupUI();
    }

    void SetupUI () {
        titleText.text = actionObject.name;
        descriptionText.text = actionObject.description;
        sprite.color = actionObject.backgroundColor;
    }
}
