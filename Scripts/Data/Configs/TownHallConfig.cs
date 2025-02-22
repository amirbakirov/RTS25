using UnityEngine;

[CreateAssetMenu(fileName = "TownHallConfig", menuName = "Scriptable Objects/TownHallConfig")]
public class TownHallConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public int buildingAreaRadius;
}
