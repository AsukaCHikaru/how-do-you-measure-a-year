using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;
    [SerializeField] private float dayToSecondRatio;

    private int day;
    private float dateTimer;

    void Start() {
        Instance = this;
        day = 1;
    }

    void Update() {
        ProgressTime();
    }

    void ProgressTime () {
        dateTimer += Time.deltaTime;
        if (dateTimer >= dayToSecondRatio) {
            dateTimer -= dayToSecondRatio;
            day++;
        }
    }

    public int GetDay () {
        return day;
    }

}
