using UnityEngine;

[CreateAssetMenu(fileName = "SmelterConfig", menuName = "Scriptable Objects/SmelterConfig")]
public class SmelterConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string resource;
}
