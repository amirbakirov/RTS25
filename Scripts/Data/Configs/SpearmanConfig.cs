using UnityEngine;

[CreateAssetMenu(fileName = "SpearmanConfig", menuName = "Scriptable Objects/SpearmanConfig")]
public class SpearmanConfig : ScriptableObject
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
