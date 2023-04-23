using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    public static ResourceController Instance;

    [SerializeField] private List<ResourceItem> resourceItemList;
    [SerializeField] internal ResourceItem saveResource;
    [SerializeField] internal ResourceItem healthResource;
    [SerializeField] internal ResourceItem mentalResource;

    void Start () {
        Instance = this;
    }

    public void HandleResourceConsumption () {
        foreach(ResourceItem item in resourceItemList) {
            item.Consume();
        }
    }
}
