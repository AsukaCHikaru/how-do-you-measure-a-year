using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenClockHandAnimeController : MonoBehaviour
{
    [SerializeField] private Transform clockHand;
    [SerializeField] private float hourToSecondRatio;

    private float timer;

    void Update () {
        timer += Time.deltaTime;
    }

    void LateUpdate () {
        HandleHandAnimation();
    }

    internal void HandleHandAnimation () {
        clockHand.localRotation = Quaternion.Euler(new Vector3(0, 0, ((timer/ hourToSecondRatio) % 24) * -15));
    }
}
