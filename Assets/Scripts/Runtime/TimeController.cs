using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;
    [SerializeField] private float dayToSecondRatio;
    [SerializeField] private ResourceController resourceController;
    [SerializeField] private HourController hourController;

    private int day;
    private float dateTimer;
    private float hourToSecondRatio;
    private int hour;
    private int lastHour;

    void Start() {
        Instance = this;
        day = 1;
        hourToSecondRatio = dayToSecondRatio / 24f;
    }

    void Update() {
        ProgressTime();
    }

    void ProgressTime () {
        dateTimer += Time.deltaTime;
        hour = Mathf.FloorToInt(dateTimer / hourToSecondRatio) % 24;
        if (lastHour != hour) {
            lastHour = hour;
            hourController.PerformHourAction(hour);
        }
        if (dateTimer >= dayToSecondRatio) {
            dateTimer -= dayToSecondRatio;
            day++;
            resourceController.HandleResourceConsumption();
        }
    }

    public int GetDay () {
        return day;
    }

}
