using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourController : MonoBehaviour {
    public static HourController Instance;

    [SerializeField] internal List<HourItem> hourItemList;
    private Dictionary<string, int> actionTimeMap = new Dictionary<string, int>() { };
    private int changeJobTimes = 0;

    void Start() {
        Instance = this;
    }

    internal void PerformHourAction(int hour) {
        HourItem hourItem = hourItemList[hour];
        int actionPerformTime = 0;
        actionTimeMap.TryGetValue(hourItem.actionItem.name, out actionPerformTime);
        if (actionPerformTime == 0) {
            actionTimeMap.Add(hourItem.actionItem.name, 1);
        } else {
            actionTimeMap[hourItem.actionItem.name] = actionPerformTime + 1;
        }
        hourItem.actionItem.Perform(actionPerformTime);
    }

    internal void ShowHourIndicator (int hour) {
        for(int h = 0; h < 24; h++) {
            if (h == hour) hourItemList[h].hourIndicator.gameObject.SetActive(true);
            else hourItemList[h].hourIndicator.gameObject.SetActive(false);
        }
    }

    internal void ResetActionTimeMap() {
        actionTimeMap.Clear();
    }
    internal void ChangeJob(int jobId) {
        ActionItem originAction;
        if (jobId == 11) {
            originAction = WorkActionController.Instance.workActionGameObject.GetComponent<ActionItem>();
        }
        else {
            originAction = WorkActionController.Instance.workGameObjectList[jobId - 12].GetComponent<ActionItem>();
        }
        foreach (HourItem hour in hourItemList) {
            ActionObject thisHourActionObject = hour.actionItem.actionObject;
            // clear job hunt
            if (thisHourActionObject.name == "Job Hunt") {
                hour.SetActionItem(GameObject.Find("IdleAction").GetComponent<ActionItem>());
            }
            // change to new job
            if (thisHourActionObject.name == "Work" && thisHourActionObject.id != jobId) {
                hour.SetActionItem(originAction);
            }
        }
        // disable other job game objects
        if (jobId == 11) {
            foreach (GameObject workGameObject in WorkActionController.Instance.workGameObjectList) {   
                workGameObject.SetActive(false);
            }
        } else {
            WorkActionController.Instance.workActionGameObject.SetActive(false);
            foreach (GameObject workGameObject in WorkActionController.Instance.workGameObjectList) {
                if (workGameObject.GetComponent<ActionItem>().actionObject.id != jobId) {
                    workGameObject.SetActive(false);
                }
            }
        }
    }

}
