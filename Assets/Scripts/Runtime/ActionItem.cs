using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionItem : MonoBehaviour
{
    [SerializeField] public ActionObject actionObject;
    [SerializeField] private ResourceItem saveResource;

    internal void Perform () {
        Debug.Log($"{actionObject.name} {actionObject.saveResourceDifference}");
        saveResource.Manipulate(actionObject.saveResourceDifference);
    }
}
