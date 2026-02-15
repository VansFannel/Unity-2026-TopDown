using UnityEngine;

public enum QuestType
{
    Move,
    Kill,
    Location
}

[CreateAssetMenu()]
public class QuestDefinition : ScriptableObject
{
    public int questID;
    public string questName;
    public string description;
    public QuestType questType;
    public int value;
}
