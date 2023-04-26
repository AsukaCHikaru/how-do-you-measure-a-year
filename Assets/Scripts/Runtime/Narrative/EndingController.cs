using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadeoutImageCanvas;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private int debtEndingThreshold;
    [SerializeField] private int sickEndingThreshold;
    [SerializeField] private int stressEndingThreshold;
    private float endingCountdown = 0;
    [SerializeField] private float endingCountdownInterval;
    private float endingTimer = 0;


    void Update()
    {
        CheckEnding();
    }

    void CheckEnding () {
        int saveValue = (int)(ResourceController.Instance.saveResource.value);
        int mentalValue = (int)(ResourceController.Instance.mentalResource.value);
        int healthValue = (int)(ResourceController.Instance.healthResource.value);
        int lowestValue = Mathf.Min(saveValue, Mathf.Min(mentalValue, healthValue));
        if (lowestValue < -30) {
            endingTimer += Time.deltaTime;
            if (endingTimer > endingCountdownInterval) {
                endingTimer -= endingCountdownInterval;
                endingCountdown += 0.05f;
                fadeoutImageCanvas.alpha = endingCountdown;
            }
        }

        if (endingCountdown >= 1) {
            GetEnding();
        }
    }

    void GetEnding () {
        endScreen.SetActive(true);
        endScreen.transform.parent.GetComponent<GraphicRaycaster>().enabled = true;
    }

    public void HandleEndClick () {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
