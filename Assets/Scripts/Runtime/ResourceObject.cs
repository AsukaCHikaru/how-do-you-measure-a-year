using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resource")]
public class ResourceObject : ScriptableObject
{
    [SerializeField] internal int consumptionPerDay;
}
