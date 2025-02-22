using UnityEngine;
using UnityEngine.UI;

public class DefaultButtons : MonoBehaviour
{
    [SerializeField] private Button _pauseBtn;

    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private Button _surrenderBtn;

    [SerializeField] private GameObject _endGamePanel;

    private void Start()
    {
        _pauseBtn.onClick.AddListener(() =>
        {
            if (Time.timeScale == 1 )
            {
                Time.timeScale = 0;
                _pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                _pausePanel.SetActive(false);
            }
        });

        _surrenderBtn.onClick.AddListener(() =>
        {
            _endGamePanel.SetActive(true);
        });
    }
}
