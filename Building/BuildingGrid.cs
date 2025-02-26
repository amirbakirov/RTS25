using UnityEngine;

public class BuildingGrid : MonoBehaviour
{
    private MapConfig _mapConfig;

    [SerializeField] private Vector2Int _gridSize;

    private Building[,] _grid;
    private Building _flyingBuilding;
    private Camera _camera;

    private int _mapSize;

    private void Awake()
    {
        _mapConfig = Resources.Load<MapConfig>("MapConfig");

        _camera = Camera.main;
    }

    private void Start()
    {
        _mapSize = Mathf.RoundToInt(Mathf.Sqrt(_mapConfig.mapSize));

        _gridSize = new Vector2Int(_mapSize, _mapSize);

        _grid = new Building[_gridSize.x, _gridSize.y];
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding);
        }

        _flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (_flyingBuilding != null)
        {
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                float halfMapSizeX = _mapSize / 2;
                float halfMapSizeZ = _mapSize / 2;

                bool isAvailable = true;

                if (x < -halfMapSizeX || x > halfMapSizeX - _flyingBuilding.Size.x) isAvailable = false;
                if (y < -halfMapSizeZ || y > halfMapSizeZ - _flyingBuilding.Size.y) isAvailable = false;

                if (isAvailable && IsPlaceTaken(x + _mapSize / 2, y + _mapSize / 2)) isAvailable = false;

                _flyingBuilding.transform.position = new Vector3(x, 0, y);
                _flyingBuilding.ShowBuildingAvailability(isAvailable);

                if (isAvailable && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x + _mapSize / 2, y + _mapSize / 2);
                    _flyingBuilding = null;
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int i = 0; i < _flyingBuilding.Size.x; i++)
        {
            for (int j = 0; j < _flyingBuilding.Size.y; j++)
            {
                if (_grid[placeX + i, placeY + j] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int i = 0; i < _flyingBuilding.Size.x; i++)
        {
            for (int j = 0;j < _flyingBuilding.Size.y; j++)
            {
                _grid[placeX + i, placeY + j] = _flyingBuilding;
            }
        }

        _flyingBuilding.Build();
        _flyingBuilding = null;
    }
}
