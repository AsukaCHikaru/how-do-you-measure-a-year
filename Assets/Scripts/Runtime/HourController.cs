using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourController : MonoBehaviour
{
    [SerializeField] private List<HourItem> hourItemList;

    internal void PerformHourAction (int hour) {
        Debug.Log(hour);
        HourItem hourItem = hourItemList[hour];
        if (hourItem != null) {
            hourItemList[hour].PerformAction();
        }
    }
}
