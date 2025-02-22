using UnityEngine;

[CreateAssetMenu(fileName = "BedsConfig", menuName = "Scriptable Objects/BedsConfig")]
public class BedsConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string resource;
}
