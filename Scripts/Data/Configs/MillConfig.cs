using UnityEngine;

[CreateAssetMenu(fileName = "MillConfig", menuName = "Scriptable Objects/MillConfig")]
public class MillConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string resource;
}
