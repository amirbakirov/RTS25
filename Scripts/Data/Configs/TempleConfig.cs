using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TempleConfig", menuName = "Scriptable Objects/TempleConfig")]
public class TempleConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string unit1;
}
