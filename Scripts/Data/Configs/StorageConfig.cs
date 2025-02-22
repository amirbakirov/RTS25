using UnityEngine;

[CreateAssetMenu(fileName = "StorageConfig", menuName = "Scriptable Objects/StorageConfig")]
public class StorageConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public int storageLimitIncrease;
}
