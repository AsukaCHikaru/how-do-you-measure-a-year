using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourController : MonoBehaviour
{
    public static HourController Instance;

    [SerializeField] internal List<HourItem> hourItemList;

    void Start () {
        Instance = this;
    }

    internal void PerformHourAction (int hour) {
        HourItem hourItem = hourItemList[hour];
    }

}
