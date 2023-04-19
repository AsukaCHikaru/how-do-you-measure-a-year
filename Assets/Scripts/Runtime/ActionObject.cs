using UnityEngine;

[CreateAssetMenu(menuName = "Action")]
public class ActionObject : ScriptableObject
{
    [SerializeField] internal new string name;
    [SerializeField, TextArea(1, 10)] internal string description;
    [SerializeField] internal int timeMinute;
    [SerializeField] internal Sprite icon;
}
