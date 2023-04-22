using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionItem : MonoBehaviour
{
    [SerializeField] public ActionObject actionObject;
    [SerializeField] private ResourceItem saveResource;
    [SerializeField] private ResourceItem healthResource;
    [SerializeField] private ResourceItem mentalResource;

    internal void Perform () {
        saveResource.Manipulate(actionObject.saveResourceDifference);
        healthResource.Manipulate(actionObject.healthResourceDifference);
        mentalResource.Manipulate(actionObject.mentalResourceDifference);
    }
}
