using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionBlockUI : MonoBehaviour
{
    [SerializeField] private Sprite[] _unitIcons;
    [SerializeField] private Sprite[] _buildingIcons;

    [SerializeField] private GameObject _soloSelection;
    [SerializeField] private Image _soloImage;
    [SerializeField] private TMP_Text _soloNameText;
    [SerializeField] private Slider _soloHealthSlider;
    [SerializeField] private GameObject _soloWorkersPanel;
    [SerializeField] private TMP_Text _workerWoodCountText;
    [SerializeField] private TMP_Text _workerStoneCountText;
    [SerializeField] private TMP_Text _workerCropsCountText;


    [SerializeField] private Transform _severalSelection;
    [SerializeField] private GameObject _severalSelectedPrefab;

    private void Start()
    {
        _soloSelection.SetActive(false);
        _soloWorkersPanel.SetActive(false);
        _severalSelection.gameObject.SetActive(false);
    }

    public void DrawSelectionUI(List<GameObject> selectedObjects)
    {
        Clear();

        if (selectedObjects.Count == 1)
        {
            _soloSelection.SetActive(true);

            string name = selectedObjects[0].tag;
            _soloNameText.text = name;

            if (LayerMask.LayerToName(selectedObjects[0].layer) == "Unit")
            {
                foreach (var icon in _unitIcons)
                {
                    if (icon.name == name)
                    {
                        _soloImage.sprite = icon;
                        break;
                    }
                }
                _soloHealthSlider.value = selectedObjects[0].GetComponent<UnitMotor>().GetHealth();

                if (name == "Builder")
                {
                    _soloWorkersPanel.SetActive(true);

                    _workerWoodCountText.text = selectedObjects[0].GetComponent<Builder>().GetTreeCount().ToString();
                    _workerStoneCountText.text = selectedObjects[0].GetComponent<Builder>().GetStoneCount().ToString();
                    _workerCropsCountText.text = selectedObjects[0].GetComponent<Builder>().GetCropsCount().ToString();
                }
            }
            else if (LayerMask.LayerToName(selectedObjects[0].layer) == "Building")
            {
                foreach (var icon in _buildingIcons)
                {
                    if (icon.name == name)
                    {
                        _soloImage.sprite = icon;
                        break;
                    }
                }
                //_soloHealthSlider.value = selectedObjects[0].GetComponent<...>().Health;
            }
        }
        else if (selectedObjects.Count > 1)
        {
            _severalSelection.gameObject.SetActive(true);

            foreach (var obj in selectedObjects)
            {
                string name = obj.tag;

                GameObject prefab = Instantiate(_severalSelectedPrefab, _severalSelection);

                if (LayerMask.LayerToName(obj.layer) == "Unit")
                {
                    foreach (var icon in _unitIcons)
                    {
                        if (icon.name == name)
                        {
                            prefab.GetComponentInChildren<Image>().sprite = icon;
                            break;
                        }
                    }
                    //prefab.GetComponentInChildren<Slider>().value = obj.GetComponent<...> ();
                }
                else if (LayerMask.LayerToName(obj.layer) == "Building")
                {
                    foreach (var icon in _buildingIcons)
                    {
                        if (icon.name == name)
                        {
                            prefab.GetComponentInChildren<Image>().sprite = icon;
                            break;
                        }
                    }
                    //prefab.GetComponentInChildren<Slider>().value = obj.GetComponent<...>();
                }

            }
        }
    }

    public void Clear()
    {
        for (int i = _severalSelection.childCount - 1; i >= 0; i--)
        {
            Destroy(_severalSelection.GetChild(i).gameObject);
        }

        _soloSelection.SetActive(false);
        _soloWorkersPanel.SetActive(false);
        _severalSelection.gameObject.SetActive(false);
    }

}
