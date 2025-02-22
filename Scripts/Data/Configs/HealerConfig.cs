using UnityEngine;

[CreateAssetMenu(fileName = "HealerConfig", menuName = "Scriptable Objects/HealerConfig")]
public class HealerConfig : ScriptableObject
{
    public string unit_name;
    public int moveSpeed;
    public int health;
    public string trainingResource;
    public int trainingResourceCount;
    public int visionZone;
    public int minHealDistance;
    public int maxHealDistance;
    public int healDelay;
    public int heal;
}
