using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkActionController : MonoBehaviour
{
    public static WorkActionController Instance;
    [SerializeField] public GameObject workActionGameObject;
    [SerializeField] private GameObject workActionGameObject_2;
    [SerializeField] private GameObject workActionGameObject_3;
    [SerializeField] private GameObject workActionGameObject_4;
    [SerializeField] private GameObject workActionGameObject_5;
    [SerializeField] public List<GameObject> workGameObjectList;
    [SerializeField] public List<ActionObject> workObjectList;

    private int currentWorkActionGameObject = 0;
    
    void Start()
    {
        Instance = this;
    }

    
    void Update()
    {
        
    }

    public GameObject GetNextJobGameObject () {
        if (currentWorkActionGameObject == 0) {
            currentWorkActionGameObject = 1;
            return workActionGameObject_2;
        }
        currentWorkActionGameObject = 0;
        return workActionGameObject;
    }

    public void RollJobHunt () {
        float knowledgeValue = ResourceController.Instance.knowledgeResource.value;
        int rollJobMax = knowledgeValue > 50 ? 4 : 3;
        int rng = Random.Range(0, rollJobMax);
        GameObject actionGameObject = workGameObjectList[rng];
        actionGameObject.SetActive(true);
    }

    public void QuitWork (int workId) {
        if (workId == 11) {
            workActionGameObject.SetActive(false);
        } else {
            workGameObjectList[workId - 12].SetActive(false);
        }

    }
}
