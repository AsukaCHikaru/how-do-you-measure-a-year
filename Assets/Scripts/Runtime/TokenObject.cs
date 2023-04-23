using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Token")]
public class TokenObject : ScriptableObject
{
    [SerializeField] internal new string name;
    [SerializeField] internal string description;
    [SerializeField] internal Sprite icon;
    [SerializeField] internal Color backgroundColor;
}
