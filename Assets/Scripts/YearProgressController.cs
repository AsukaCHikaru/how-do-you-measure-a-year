using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

public class YearProgressController : MonoBehaviour
{
    [SerializeField] private Image progressBarImage;
    [SerializeField] private TextMeshProUGUI progressDateText;

    CultureInfo culture;

    void Start () {
         culture = new CultureInfo("en-US");
    }

    void Update () {
        ProgressBar();
        ProgressDate();
    }

    void ProgressBar () {
        progressBarImage.fillAmount = (float)TimeController.Instance.GetDay()  / 365f;
    }

    void ProgressDate () {
        DateTime dt = DateTime.Parse("2019-12-31").AddDays(TimeController.Instance.GetDay());
        string dateString = dt.ToString("MMMM d", culture);
        progressDateText.text = dateString;
        
    }
}
