using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceItem : MonoBehaviour {
    [SerializeField] internal ResourceObject resourceObject;
    [SerializeField] internal int value;
    [SerializeField] internal int defaultValue;
    [SerializeField] private TextMeshProUGUI valueText;

    void Start() {
        value = defaultValue;
    }

    void LateUpdate () {
        UpdateUI();
    }

    internal void Consume() {
        value -= resourceObject.consumptionPerDay;
    }

    internal void Manipulate (int difference) {
        value += difference;
    }

    void UpdateUI() {
        valueText.text = value.ToString();
    }
}
