using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "Scriptable Objects/MapConfig")]
public class MapConfig : ScriptableObject
{
    public int enemyCount;
    public List<Enemy> enemyList;
    public string playerName;
    public Color playerColor;
    public string difficulty;
    public int mapSize;
}

public struct Enemy
{
    public string name;
    public Color color;
}