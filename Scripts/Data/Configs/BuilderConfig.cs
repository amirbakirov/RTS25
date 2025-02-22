using UnityEngine;

[CreateAssetMenu(fileName = "BuilderConfig", menuName = "Scriptable Objects/BuilderConfig")]
public class BuilderConfig : ScriptableObject
{
    public string unit_name;
    public int moveSpeed;
    public int health;
    public string trainingResource;
    public int trainingResourceCount;
    public int visionZone;
    public int extractionTime;
    public int repairTime;
    public int repairEfficiency;
}
