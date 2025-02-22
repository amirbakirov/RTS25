using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamemodeSettingsUI : MonoBehaviour
{
    private MapConfig _mapConfig;

    [SerializeField] private TMP_Dropdown _enemyCountDropdown;
    [SerializeField] private TMP_Dropdown _difficultyDropdown;
    [SerializeField] private TMP_InputField _mapSizeInput;

    [SerializeField] private RectTransform _enemiesParent;
    [SerializeField] private GameObject _enemyPanelPrefab;

    [SerializeField] private GameObject _playerPanel;
    [SerializeField] private TMP_InputField _playerNameInput;
    [SerializeField] private Button _playerColorBtn;
    [SerializeField] private Image _playerBtnImg;

    [SerializeField] private Button _playBtn;

    private List<GameObject> _enemyList = new List<GameObject>();


    private readonly List<Color> colors = new List<Color>() { Color.red, Color.black, Color.yellow, Color.blue, Color.green, Color.gray, Color.white };
    private bool _namesFlag = true;

    private void Start()
    {
        _enemyList.Clear();

        _enemyCountDropdown.onValueChanged.AddListener(EnemyCountChanged);

        _playerNameInput.onEndEdit.AddListener(CheckNames);

        _playerColorBtn.onClick.AddListener(() =>
        {
            ChangeColor(_playerBtnImg);
        });

        _playBtn.onClick.AddListener(() =>
        {
            CheckNames("");
            if (!_namesFlag || !CheckColors())
                return;
            if (int.Parse(_mapSizeInput.text) < 2500 || int.Parse(_mapSizeInput.text) > 10000)
                return;

            _mapConfig = Resources.Load<MapConfig>("MapConfig");
            _mapConfig.enemyCount = _enemyList.Count;

            List<Enemy> enemies = new List<Enemy>();
            foreach (var i in _enemyList)
            {
                Enemy enemy = new Enemy();
                enemy.name = i.GetComponentInChildren<TMP_Text>().text;
                enemy.color = i.GetComponentInChildren<Button>().GetComponent<Image>().color;

                enemies.Add(enemy);
            }

            _mapConfig.enemyList = enemies;
            _mapConfig.playerName = _playerNameInput.text;
            _mapConfig.playerColor = _playerBtnImg.color;
            int difficult = _difficultyDropdown.value;
            if (difficult == 0)
                _mapConfig.difficulty = "Easy";
            else if (difficult == 1)
                _mapConfig.difficulty = "Middle";
            else if (difficult == 2)
                _mapConfig.difficulty = "Difficult";
            _mapConfig.mapSize = int.Parse(_mapSizeInput.text);

            SceneManager.LoadScene("Game");
        });


        EnemyCountChanged(0);
    }

    private void CheckNames(string value)
    {
        _namesFlag = true;
        bool curFlag = true;
        List<GameObject> list = new List<GameObject>();
        foreach (GameObject go in _enemyList)
        {
            list.Add(go);
        }
        list.Add(_playerPanel);
        for (int i = 0; i < list.Count; i++)
        {
            curFlag = true;
            for (int j = 0; j < list.Count; j++)
            {
                if (i == j)
                    continue;
                TMP_Text enemy1 = list[i].GetComponentInChildren<TMP_Text>();
                TMP_Text enemy2 = list[j].GetComponentInChildren<TMP_Text>();


                if (enemy1.text == enemy2.text)
                {
                    enemy1.color = enemy2.color = Color.red;
                    _namesFlag = false;
                    curFlag = false;
                }
            }
            if (curFlag)
            {
                list[i].GetComponentInChildren<TMP_Text>().color = Color.white;
            }
        }
        if (curFlag)
        {
            list[list.Count - 1].GetComponentInChildren<TMP_Text>().color = Color.white;
        }

        if (_namesFlag)
        {
            foreach (var i in list)
            {
                i.GetComponentInChildren<TMP_Text>().color = Color.white;
            }
        }
    }

    private bool CheckColors()
    {
        List<GameObject> list = new List<GameObject>();
        foreach (GameObject go in _enemyList)
        {
            list.Add(go);
        }
        list.Add(_playerPanel);
        for (int i = 0; i < list.Count; i++)
        {
            Color enemy1 = list[i].GetComponentInChildren<Button>().GetComponent<Image>().color;
            for (int j = 0; j < list.Count; j++)
            {
                if (i == j)
                    continue;

                Color enemy2 = list[j].GetComponentInChildren<Button>().GetComponent<Image>().color;

                if (enemy1 == enemy2)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void EnemyCountChanged(int val)
    {
        int value = int.Parse(_enemyCountDropdown.options[val].text);
        _enemiesParent.sizeDelta = new Vector2(_enemiesParent.rect.x, 54 * value + 20 * (value - 1));

        while (_enemyList.Count < value)
        {
            GameObject enemy =  Instantiate(_enemyPanelPrefab, Vector3.zero, Quaternion.identity, _enemiesParent);

            enemy.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                ChangeColor(enemy.GetComponentInChildren<Button>().GetComponent<Image>());
            });

            enemy.GetComponentInChildren<TMP_InputField>().onEndEdit.AddListener(CheckNames);

            enemy.GetComponent<RectTransform>().localPosition = Vector3.zero;
            _enemyList.Add(enemy);
        }

        while (_enemyList.Count > value)
        {
            Destroy(_enemyList[_enemyList.Count - 1]);
            _enemyList.RemoveAt(_enemyList.Count - 1);
        }

        CheckNames("");
    }

    private void ChangeColor(Image img)
    {
        img.color = colors[(colors.IndexOf(img.color) + 1) % colors.Count];
    }
}
