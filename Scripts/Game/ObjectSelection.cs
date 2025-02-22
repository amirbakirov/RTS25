using System.Collections.Generic;
using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    [SerializeField] private CommandsUI _commandsUI;
    [SerializeField] private SelectionBlockUI _selectionBlockUI;

    private Vector3 _startMousePosition;
    private bool _isSelecting;
    [SerializeField] private List<GameObject> _selectedObjects = new List<GameObject>();

    [SerializeField] private RectTransform _selectingBox;
    private Vector2 _boxStartPosition;

    private bool _isCanClick = true;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (LayerMask.LayerToName(hit.collider.gameObject.layer) == "UI")
            {
                return;
            }
        }

        if (!_isCanClick)
        {
            _isSelecting = false;
            _selectingBox.gameObject.SetActive(false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!_isSelecting)
            {
                _startMousePosition = Input.mousePosition;
                _boxStartPosition = Input.mousePosition;
                _isSelecting = true;
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    RemoveObjects();
                }
                _selectingBox.gameObject.SetActive(true);
            }
        }

        if (_isSelecting)
        {
            UpdateSelectionBox(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isSelecting = false;
            _selectingBox.gameObject.SetActive(false);

            if (_startMousePosition == Input.mousePosition)
            {
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    RemoveObjects();
                }

                HandleObjectClick();
                _commandsUI.SelectedObject(_selectedObjects);
                _selectionBlockUI.DrawSelectionUI(_selectedObjects);
                return;
            }

            SelectedObjectInArea(_startMousePosition, Input.mousePosition);

            _commandsUI.SelectedObject(_selectedObjects);
            _selectionBlockUI.DrawSelectionUI(_selectedObjects);
        }
    }

    public void IsCanClick(bool canClick) { _isCanClick = canClick; }

    public List<GameObject> GetSelectedObjectsList() {  return _selectedObjects; }

    private GameObject CheckClickedObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject clickedObject = hit.collider.gameObject;
            if (IsSelectable(clickedObject))
            {
                return clickedObject;
            }
        }

        return null;
    }

    private void HandleObjectClick()
    {
        if (CheckClickedObject() != null)
        {
            AddObject(CheckClickedObject());
        }
    }

    private void SelectedObjectInArea(Vector2 start, Vector2 end)
    {
        Bounds selectedBounds = new Bounds();
        selectedBounds.SetMinMax(
            Vector2.Min(start, end),
            Vector2.Max(start, end)
            );

        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (IsSelectable(obj) && selectedBounds.Contains((Vector2)Camera.main.WorldToScreenPoint(obj.transform.position)))
            {
                AddObject(obj);
            }
        }

    }

    public void RemoveObjects()
    {
        foreach (var i in _selectedObjects)
        {
            i.transform.Find("Outline").GetChild(0).gameObject.SetActive(false);
        }

        _selectedObjects.Clear();
    }

    private void AddObject(GameObject obj)
    {
        if (_selectedObjects.Contains(obj))
            return;

        obj.transform.Find("Outline").GetChild(0).gameObject.SetActive(true);
        _selectedObjects.Add(obj);
    }

    private bool IsSelectable(GameObject obj)
    {
        string layerName = LayerMask.LayerToName(obj.layer);
        return layerName == "Unit" || layerName == "Building";
    }

    private void UpdateSelectionBox(Vector3 currentMousePosition)
    {
        if (!_selectingBox) return;

        float width = currentMousePosition.x - _boxStartPosition.x;
        float height = currentMousePosition.y - _boxStartPosition.y;

        _selectingBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        _selectingBox.anchoredPosition = _boxStartPosition - new Vector2(Screen.width / 2, Screen.height / 2) + new Vector2(width / 2, height / 2);
    }
}
