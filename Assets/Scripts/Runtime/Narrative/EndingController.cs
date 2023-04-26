using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingController : MonoBehaviour
{
    public static EndingController Instance;

    [SerializeField] private CanvasGroup fadeoutImageCanvas;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject GoodEndScreen;
    [SerializeField] private int endingThreshold;
    private float endingCountdown = 0;
    [SerializeField] private float endingCountdownInterval;
    private float endingTimer = 0;

    void Start () {
        Instance = this;
    }

    void Update()
    {
        CheckEnding();
    }

    void CheckEnding () {
        int saveValue = (int)(ResourceController.Instance.saveResource.value);
        int mentalValue = (int)(ResourceController.Instance.mentalResource.value);
        int healthValue = (int)(ResourceController.Instance.healthResource.value);
        int lowestValue = Mathf.Min(saveValue, Mathf.Min(mentalValue, healthValue));
        if (lowestValue < endingThreshold) {
            endingTimer += Time.deltaTime;
            if (endingTimer > endingCountdownInterval) {
                endingTimer -= endingCountdownInterval;
                endingCountdown += 0.05f;
                fadeoutImageCanvas.alpha = endingCountdown;
            } else {
                endingCountdown -= 0.05f;
                if (endingCountdown < 0) {
                    endingCountdown = 0;
                }
            }
        }

        if (isGoodEnding) {
            endingCountdown += 0.05f;
            fadeoutImageCanvas.alpha = endingCountdown;
        }

        if (endingCountdown >= 1 && GoodEndScreen.activeInHierarchy == false) {
            if (!isGoodEnding) {
                GetEnding();
            } else {
                ShowGoodEnding();
            }
        }
    }

    void GetEnding () {
        endScreen.SetActive(true);
        endScreen.transform.parent.GetComponent<GraphicRaycaster>().enabled = true;
    }

    public void HandleEndClick () {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }

    private bool isGoodEnding = false;

    public void StartGoodEnding () {
        isGoodEnding = true;
    }

    void ShowGoodEnding () {
        GoodEndScreen.SetActive(true);
        endScreen.transform.parent.GetComponent<GraphicRaycaster>().enabled = true;

        int readTime = GameObject.Find("ReadAction").GetComponent<ActionItem>().allTimePerformTime;
        int exerciseTime = GameObject.Find("ExerciseAction").GetComponent<ActionItem>().allTimePerformTime;

        GoodEndScreen.transform.Find("text").GetComponent<TextMeshProUGUI>().text =
            $"You changed job {1} times;\n" +
            $"read {readTime} hours;\n" +
            $"exercised {exerciseTime} hours.\n";
        
    }
}
