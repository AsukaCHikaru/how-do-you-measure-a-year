using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;
    [SerializeField] private float dayToSecondRatio;
    [SerializeField] private ResourceController resourceController;
    [SerializeField] private HourController hourController;
    [SerializeField] private GameObject goodEndScreen;

    private int day;
    private float dateTimer;
    internal float hourToSecondRatio;
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
            // Debug.Log(hour);
            lastHour = hour;
            hourController.PerformHourAction(hour);
            hourController.ShowHourIndicator(hour);
        }
        if (dateTimer >= dayToSecondRatio) {
            dateTimer -= dayToSecondRatio;
            day++;
            hourController.ResetActionTimeMap();
            resourceController.HandleResourceConsumption();

            if (day >= 365 && goodEndScreen.activeInHierarchy == false) {
                EndingController.Instance.StartGoodEnding();
            }
        }
    }

    public int GetDay () {
        return day;
    }

    public float GetTimer () {
        return dateTimer;
    }

}
