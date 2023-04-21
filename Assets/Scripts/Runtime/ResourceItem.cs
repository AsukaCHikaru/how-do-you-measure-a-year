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

    internal void Consume() {
        value -= resourceObject.consumptionPerDay;
        UpdateUI();
    }

    void UpdateUI() {
        valueText.text = value.ToString();
    }
}
