using UnityEngine;

[CreateAssetMenu(fileName = "HeavyWarriorConfig", menuName = "Scriptable Objects/HeavyWarriorConfig")]
public class HeavyWarriorConfig : ScriptableObject
{
    public string unit_name;
    public int moveSpeed;
    public int health;
    public string trainingResource;
    public int trainingResourceCount;
    public int visionZone;
    public int minAttackDistance;
    public int maxAttackDistance;
    public int attackDelay;
    public int damage;
}
