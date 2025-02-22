using UnityEngine;

[CreateAssetMenu(fileName = "CatapultConfig", menuName = "Scriptable Objects/CatapultConfig")]
public class CatapultConfig : ScriptableObject
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
