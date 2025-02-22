using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Builder : UnitMotor
{
    private BuilderConfig _config;

    private MapGenerator _mapGenerator;

    [SerializeField] private int _treeCount;
    [SerializeField] private int _stoneCount;
    [SerializeField] private int _cropsCount;

    private int _extractionTime;
    private int _repairTime;
    private int _repairEfficiency;

    [SerializeField] private GameObject _objectForBuilder;

    private void Awake()
    {
        _config = Resources.Load<BuilderConfig>("BuilderConfig");
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _mapGenerator = FindAnyObjectByType<MapGenerator>();
        m_SelectionBlockUI = FindAnyObjectByType<SelectionBlockUI>();
        m_CommandsUI = FindAnyObjectByType<CommandsUI>();

        _name = _config.name;
        _moveSpeed = _config.moveSpeed;
        _health = _config.health;
        _trainingResource = _config.trainingResource;
        _trainingResourceCount = _config.trainingResourceCount;
        _visionZone = _config.visionZone;

        _extractionTime = _config.extractionTime;
        _repairTime = _config.repairTime;
        _repairEfficiency = _config.repairEfficiency;

        _agent.speed = _moveSpeed;
        _agent.angularSpeed = 180;
        _agent.acceleration = 1000;
        _agent.stoppingDistance = 0.7f;
    }

    private void Update()
    {
        if (_isMoving)
        {
            Move(_directionPosition);
            if (Vector3.Distance(transform.position, _directionPosition) < 2f)
            {
                _isMoving = false;

                if (_objectForBuilder.tag == "tree" || _objectForBuilder.tag == "stone" || _objectForBuilder.tag == "Beds")
                {
                    StartCoroutine(WaitSecondsSecondsCollectResource(_extractionTime, _objectForBuilder));
                }
                else
                {
                    ///
                }
            }
        }
    }

    public override void Move(Vector3 direction)
    {
        if (_agent.velocity.magnitude < _agent.speed)
        {
            _agent.velocity = _agent.desiredVelocity.normalized * _agent.speed;
        }

        _agent.SetDestination(direction);
    }

    public override void SecondCommandButton(GameObject obj)
    {
        m_SelectionBlockUI.Clear();
        m_CommandsUI.Clear();

        if (obj.tag != "tree" && obj.tag != "stone" && obj.tag != "Beds" && obj.tag != "...Building...")
            return;


        base.SecondCommandButton(obj);

        _objectForBuilder = obj;
    }

    private IEnumerator WaitSecondsSecondsCollectResource(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);

        if (obj.tag == "tree")
        {
            _treeCount++;

            Destroy(obj);
        }
        else if (obj.tag == "stone")
        {
            _stoneCount++;

            Destroy(obj);
        }
        else if (obj.tag == "Beds")
        {
            _cropsCount++;
        }

        _mapGenerator.UpdateNavMeshSurface();
    }

    public int GetTreeCount() {  return _treeCount; }
    public int GetStoneCount() { return _stoneCount; }
    public int GetCropsCount() { return _cropsCount; }
}
