using UnityEngine;
using UnityEngine.AI;

public class UnitMotor : MonoBehaviour
{
    protected SelectionBlockUI m_SelectionBlockUI;
    protected CommandsUI m_CommandsUI;

    protected NavMeshAgent _agent;

    protected string _name;
    protected int _moveSpeed;
    protected int _health;
    protected string _trainingResource;
    protected int _trainingResourceCount;
    protected int _visionZone;

    protected Vector3 _directionPosition;
    protected bool _isMoving;

    private void Update()
    {
    }

    public virtual void Move(Vector3 direction)
    {

    }

    public virtual void RightMouseClick(Vector3 position, GameObject obj)
    {
    }

    public virtual void FirstCommandButton()
    {
    }

    public virtual void SecondCommandButton(GameObject obj)
    {
        _isMoving = true;
        _directionPosition = obj.transform.position;
    }

    public string GetName()
    {
        return _name;
    }
    public int GetHealth()
    {
        return _health;
    }
}
