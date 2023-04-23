using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceItem : MonoBehaviour {
    [SerializeField] internal ResourceObject resourceObject;
    [SerializeField] internal float value;
    [SerializeField] internal float defaultValue;
    [SerializeField] internal float maxValue;
    [SerializeField] private TextMeshProUGUI valueText;

    void Start() {
        value = defaultValue;
    }

    void LateUpdate () {
        UpdateUI();
    }

    internal void Consume() {
        value -= resourceObject.consumptionPerDay;
        if (value <= 0) {
            value = 0;
        }
    }

    internal void Manipulate (float difference) {
        // Debug.Log($"{resourceObject.name} {difference}");
        value += difference;
        if (value < 0) {
            value = 0;
        }
        if (value > maxValue) {
            value = maxValue;
        }
    }

    void UpdateUI() {
        valueText.text = Mathf.Floor(value).ToString();
    }
}
