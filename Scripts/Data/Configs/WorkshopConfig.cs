using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkshopConfig", menuName = "Scriptable Objects/WorkshopConfig")]
public class WorkshopConfig : ScriptableObject
{
    public int strength;
    public string buildResource;
    public int buildResourceCount;
    public string unit1;
    public string unit2;
}
