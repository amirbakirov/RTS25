using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BarracksConfig", menuName = "Scriptable Objects/BarracksConfig")]
public class BarracksConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string unit1;
    public string unit2;
    public string unit3;
}
