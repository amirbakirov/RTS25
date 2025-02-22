using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private float _moveSpeed = 20f;
    private Camera _camera;

    private float _minZoom = 5f;
    private float _maxZoom = 10f;
    private float _zoomSpeed = 25f;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        Vector2 mousePos = Input.mousePosition;

        if (//(mousePos.x < 20 && mousePos.y > 20 && mousePos.y < Screen.height - 20) ||
            Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
        else if (//(mousePos.x > Screen.width - 20 && mousePos.y > 20 && mousePos.y < Screen.height - 20) ||
                Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * _moveSpeed * Time.deltaTime;
        }
        else if (//(mousePos.y < 20 && mousePos.x > 20 && mousePos.x < Screen.width - 20) ||
                Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * _moveSpeed * Time.deltaTime;
        }
        else if (//(mousePos.y > Screen.height - 20 && mousePos.x > 20 && mousePos.x < Screen.width - 20) ||
                Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
        }
    }

    private void Zoom()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (_camera.orthographicSize > _minZoom)
            {
                _camera.orthographicSize -= _zoomSpeed * Time.deltaTime;
            }
            else
            {
                return;
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (_camera.orthographicSize < _maxZoom)
            {
                _camera.orthographicSize += _zoomSpeed * Time.deltaTime;
            }
            else
            {
                return;
            }
        }
    }
}
