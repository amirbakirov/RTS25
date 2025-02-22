using UnityEngine;

public class CommandsController : MonoBehaviour
{
    [SerializeField] private ObjectSelection _objectSelection;

    protected bool _isRepair = false;
    protected bool _isResource = false;
    protected bool _isPatrollingWarrior = false;
    protected bool _isHeal = false;
    protected bool _isPatrollingHealer = false;
    protected bool _isUpgrade = false;

    private bool _isClickedOnObject = false;

    private void Update()
    {
        if (_isRepair)
        {
            _objectSelection.IsCanClick(false);

        }
        else if (_isResource)
        {
            _objectSelection.IsCanClick(false);

            if (Input.GetMouseButtonDown(0))
            {
                foreach (var obj in _objectSelection.GetSelectedObjectsList())
                {
                    if (obj.tag == "Builder")
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        GameObject clickedObject = null;

                        if (Physics.Raycast(ray, out hit))
                        {
                            clickedObject = hit.collider.gameObject;
                        }

                        obj.GetComponent<Builder>().SecondCommandButton(clickedObject);
                    }
                }
                _objectSelection.RemoveObjects();

                _isClickedOnObject = true;
            }
            if (_isClickedOnObject)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    _isResource = false;

                    _isClickedOnObject = false;
                }
            }
        }
        else if (_isPatrollingWarrior)
        {
            _objectSelection.IsCanClick(false);

        }
        else if (_isHeal)
        {
            _objectSelection.IsCanClick(false);

        }
        else if (_isPatrollingHealer)
        {
            _objectSelection.IsCanClick(false);

        }
        else if (_isUpgrade)
        {
            _objectSelection.IsCanClick(false);

        }
        else
        {
            _objectSelection.IsCanClick(true);
        }
    }
}
