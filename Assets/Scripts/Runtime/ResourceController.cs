using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    [SerializeField] private List<ResourceItem> resourceItemList;

    public void HandleResourceConsumption () {
        foreach(ResourceItem item in resourceItemList) {
            item.Consume();
        }
    }
}
