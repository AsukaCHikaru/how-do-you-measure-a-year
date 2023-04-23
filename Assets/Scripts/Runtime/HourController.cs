using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourController : MonoBehaviour
{
    public static HourController Instance;

    [SerializeField] internal List<HourItem> hourItemList;
    private Dictionary<string, int> actionTimeMap = new Dictionary<string, int>() { };

    void Start () {
        Instance = this;
    }

    internal void PerformHourAction (int hour) {
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

    internal void ResetActionTimeMap () {
        actionTimeMap.Clear();
    }

}
