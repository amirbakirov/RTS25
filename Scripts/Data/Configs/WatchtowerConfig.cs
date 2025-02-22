using UnityEngine;

[CreateAssetMenu(fileName = "WatchtowerConfig", menuName = "Scriptable Objects/WatchtowerConfig")]
public class WatchtowerConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public int enemyDetectionRadius;
    public int buildingAreaRadius;
    public int archerCapacity;
    public int minAttackDistance;
    public int maxAttackDistance;
    public int attackDelay;
    public int damage;
}
