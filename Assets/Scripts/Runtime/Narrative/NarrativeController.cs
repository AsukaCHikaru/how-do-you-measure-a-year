using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    [SerializeField] private ActionItem workAction;
    [SerializeField] private ActionItem sleepAction;
    [SerializeField] private ActionItem breakfastAction;
    [SerializeField] private ActionItem lunchAction;
    [SerializeField] private ActionItem dinnerAction;
    [SerializeField] private ActionItem socialmediaAction;

    private bool isDefaultSet = false;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    private void SetupDefaultActions () {
        HourController.Instance.hourItemList[0].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[1].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[2].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[3].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[4].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[5].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[6].SetActionItem(sleepAction);
        HourController.Instance.hourItemList[7].SetActionItem(breakfastAction);
        HourController.Instance.hourItemList[8].SetActionItem(workAction);
        HourController.Instance.hourItemList[9].SetActionItem(workAction);
        HourController.Instance.hourItemList[10].SetActionItem(workAction);
        HourController.Instance.hourItemList[11].SetActionItem(workAction);
        HourController.Instance.hourItemList[12].SetActionItem(lunchAction);
        HourController.Instance.hourItemList[13].SetActionItem(workAction);
        HourController.Instance.hourItemList[14].SetActionItem(workAction);
        HourController.Instance.hourItemList[15].SetActionItem(workAction);
        HourController.Instance.hourItemList[16].SetActionItem(workAction);
        HourController.Instance.hourItemList[17].SetActionItem(workAction);
        HourController.Instance.hourItemList[18].SetActionItem(workAction);
        HourController.Instance.hourItemList[19].SetActionItem(workAction);
        HourController.Instance.hourItemList[20].SetActionItem(dinnerAction);
        HourController.Instance.hourItemList[21].SetActionItem(socialmediaAction);
        HourController.Instance.hourItemList[22].SetActionItem(socialmediaAction);
        HourController.Instance.hourItemList[23].SetActionItem(socialmediaAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDefaultSet) {
            SetupDefaultActions();
            isDefaultSet = true;
        }
    }
}
