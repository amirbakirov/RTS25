using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResidentialBuildingConfig", menuName = "Scriptable Objects/ResidentialBuildingConfig")]
public class ResidentialBuildingConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string unit1;
}
