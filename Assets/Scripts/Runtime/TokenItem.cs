using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenItem : MonoBehaviour
{
    [SerializeField] internal TokenObject tokenObject;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private SpriteRenderer sprite;

    void Start() {
        if (tokenObject != null) {
            SetupUI();
        }
    }

    public void SetToken (TokenObject token) {
        tokenObject = token;
        SetupUI();
    }

    void SetupUI () {
        titleText.text = tokenObject.name;
        descriptionText.text = tokenObject.description;
        sprite.color = tokenObject.backgroundColor;
    }
}
