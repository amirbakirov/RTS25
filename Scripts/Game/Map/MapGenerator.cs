using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    private MapConfig _mapConfig;

    [SerializeField] private NavMeshSurface _navMeshSurface;

    [SerializeField] private XMLController _xmlController;

    [SerializeField] private Terrain _terrain;
    [SerializeField] private Transform _resourcesParent;
    [SerializeField] private Transform _distanceCubesParent;

    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private GameObject _stonePrefab;

    [SerializeField] private float _treeChance;
    [SerializeField] private float _stoneChance;

    [SerializeField] private GameObject _distanceCubePrefab;

    [SerializeField] private Transform _basesParent;
    [SerializeField] private GameObject _playerBase;
    [SerializeField] private GameObject _enemyBase;

    private void Awake()
    {
        _mapConfig = Resources.Load<MapConfig>("MapConfig");

        _playerBase.GetComponent<SphereCollider>().radius = _xmlController.GetFreeZoneRadius();
        _enemyBase.GetComponent<SphereCollider>().radius = _xmlController.GetFreeZoneRadius();
    }

    private void Start()
    {
        GenerateMap(_mapConfig.mapSize);
    }

    private void GenerateMap(int mapSize)
    {
        Clear();

        mapSize = Mathf.RoundToInt(Mathf.Sqrt(mapSize));

        _terrain.terrainData.size = new Vector3(mapSize, 100, mapSize);

        float randomMultiplier = Random.Range(-100f, 100f);

        for (float i = 0; i < mapSize / 10; i += 0.1f)
        {
            for (float j = 0; j < mapSize / 10; j += 0.1f)
            {
                float noise = Mathf.PerlinNoise(i + randomMultiplier, j + randomMultiplier);

                if (noise > 0.4f)
                {
                    SpawnResources(i * 10, j * 10, noise, Random.Range(-3f, 3f));
                }
            }
        }

        GameObject obj = Instantiate(_distanceCubePrefab, new Vector3(0.5f, 0.5f, 0.5f), Quaternion.identity, _distanceCubesParent);
        obj.transform.GetComponentInChildren<TMP_Text>().text = Mathf.Sqrt(2 * mapSize * mapSize).ToString();
        Instantiate(_distanceCubePrefab, new Vector3(mapSize - 0.5f, 0.5f, mapSize - 0.5f), Quaternion.identity, _distanceCubesParent);

        SpawnBases(_mapConfig.enemyCount + 1, mapSize);

        _navMeshSurface.BuildNavMesh();

        transform.position = new Vector3(-mapSize / 2, 0, -mapSize / 2);
    }

    public void UpdateNavMeshSurface()
    {
        _navMeshSurface.BuildNavMesh();
    }

    private void SpawnResources(float x, float z, float noise, float multiplier)
    {
        noise += multiplier;

        var position = new Vector3(x + multiplier, 0, z + multiplier);

        if (noise >= _treeChance)
        {
            Instantiate(_treePrefab, position, Quaternion.identity, _resourcesParent);
        }
        else if (noise < _stoneChance)
        {
            Instantiate(_stonePrefab, position, Quaternion.identity, _resourcesParent);
        }
    }

    private void SpawnBases(int count, int mapSize)
    {
        Vector3 center = _terrain.transform.position + new Vector3(mapSize / 2, 0, mapSize / 2);
        int _spawnRadius = -mapSize / 2 + 5;
        for (int i = 0; i < count; i++)
        {
            var angle = (i * Mathf.PI * 2f) / count;
            Vector3 position = center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _spawnRadius;

            if (i == 0)
            {
                GameObject baseObj = Instantiate(_playerBase, position, Quaternion.identity, _basesParent);

                baseObj.GetComponentInChildren<TMP_Text>().text = _mapConfig.playerName;
            }
            else
            {
                GameObject baseObj = Instantiate(_enemyBase, position, Quaternion.identity, _basesParent);

                baseObj.GetComponentInChildren<TMP_Text>().text = _mapConfig.enemyList[i - 1].name;
            }
        }
    }

    private void Clear()
    {
        while (_resourcesParent.childCount > 0)
        {
            Destroy(_resourcesParent.GetChild(0).gameObject);
        }

        while (_distanceCubesParent.childCount > 0)
        {
            Destroy(_distanceCubesParent.GetChild(0).gameObject);
        }
    }
}
