using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockHandAnimeController : MonoBehaviour
{
    [SerializeField] private Transform clockHand;
    [SerializeField] private TimeController timeController;

    void LateUpdate () {
        HandleHandAnimation();
    }

    internal void HandleHandAnimation () {
        clockHand.localRotation = Quaternion.Euler(new Vector3(0, 0, ((timeController.GetTimer() / timeController.hourToSecondRatio) % 24) * -15));
    }
}
