using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScreen : MonoBehaviour
{
    [SerializeField] private GameObject creditScreen;

    public void ShowCredit () {
        creditScreen.SetActive(true);
    }

    public void HideCredit() {
        creditScreen.SetActive(false);
    }
}
