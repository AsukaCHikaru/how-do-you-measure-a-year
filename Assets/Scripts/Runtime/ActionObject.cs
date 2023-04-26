using UnityEngine;

[CreateAssetMenu(menuName = "Action")]
public class ActionObject : ScriptableObject
{
    [SerializeField] internal new string name;
    [SerializeField, TextArea(1, 10)] internal string description;
    [SerializeField] internal int timeMinute;
    [SerializeField] internal Sprite icon;
    [SerializeField] internal Color backgroundColor;
    [SerializeField] internal int id;

    [SerializeField] internal float[] saveResourceDifferenceList = new float[24];
    [SerializeField] internal float[] healthResourceDifferenceList = new float[24];
    [SerializeField] internal float[] mentalResourceDifferenceList = new float[24];
    [SerializeField] internal float[] knowledgeResourceDifferenceList = new float[24];
}
