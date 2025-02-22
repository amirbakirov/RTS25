using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsUI : CommandsController
{
    [SerializeField] private GameObject _builderPanelLeft;
    [SerializeField] private GameObject _trainingBarracksPanelLeft;
    [SerializeField] private GameObject _trainingResidentialBuildingPanelLeft;
    [SerializeField] private GameObject _trainingWorkshopPanelLeft;
    [SerializeField] private GameObject _trainingTemplePanelLeft;
    [SerializeField] private GameObject _emptyPanelLeft;

    [SerializeField] private GameObject _severalSelectionPanelRight;
    [SerializeField] private GameObject _builderPanelRight;
    [SerializeField] private GameObject _warriorsPanelRight;
    [SerializeField] private GameObject _healerPanelRight;
    [SerializeField] private GameObject _trainingPanelRight;
    [SerializeField] private GameObject _emptyPanelRight;


    [SerializeField] private Button[] _handBtn;
    [SerializeField] private Button _repairBtn;
    [SerializeField] private Button _resourceBtn;
    [SerializeField] private Button _patrollingWarriorBtn;
    [SerializeField] private Button _healBtn;
    [SerializeField] private Button _patrollingHealerBtn;
    [SerializeField] private Button _upgradeBtn;

    private void Start()
    {
        Clear();

        _repairBtn.onClick.AddListener(() =>
        {
            _isRepair = true;
        });
        _resourceBtn.onClick.AddListener(() =>
        {
            _isResource = true;
        });
        _patrollingWarriorBtn.onClick.AddListener(() =>
        {
            _isPatrollingWarrior = true;
        });
        _healBtn.onClick.AddListener(() =>
        {
            _isHeal = true;
        });
        _patrollingHealerBtn.onClick.AddListener(() =>
        {
            _isPatrollingHealer = true;
        });
        _upgradeBtn.onClick.AddListener(() =>
        {
            _isUpgrade = true;
        });
    }

    public void SelectedObject(List<GameObject> selectedObjects)
    {
        Clear();

        if (selectedObjects.Count != 1)
        {
            for (int i = 1; i < selectedObjects.Count; i++)
            {
                if (selectedObjects[i - 1].tag != selectedObjects[i].tag)
                {
                    _severalSelectionPanelRight.SetActive(true);

                    return;
                }
            }

            return;
        }

        GameObject obj = selectedObjects[0];

        if (obj.tag == "Builder")
        {
            _builderPanelLeft.SetActive(true);
            _builderPanelRight.SetActive(true);

            _emptyPanelLeft.SetActive(false);
            _emptyPanelRight.SetActive(false);
        }
        else if (obj.tag == "Healer")
        {
            _healerPanelRight.SetActive(true);
            _emptyPanelRight.SetActive(false);
        }
        else if (LayerMask.LayerToName(obj.layer) == "Unit")
        {
            _warriorsPanelRight.SetActive(true);
            _emptyPanelRight.SetActive(false);
        }
        else if (obj.tag == "Barracks")
        {
            _trainingBarracksPanelLeft.SetActive(true);
            _trainingPanelRight.SetActive(true);

            _emptyPanelLeft.SetActive(false);
            _emptyPanelRight.SetActive(false);
        }
        else if (obj.tag == "ResidentialBuilding")
        {
            _trainingResidentialBuildingPanelLeft.SetActive(true);
            _trainingPanelRight.SetActive(true);

            _emptyPanelLeft.SetActive(false);
            _emptyPanelRight.SetActive(false);
        }
        else if (obj.tag == "Workshop")
        {
            _trainingWorkshopPanelLeft.SetActive(true);
            _trainingPanelRight.SetActive(true);

            _emptyPanelLeft.SetActive(false);
            _emptyPanelRight.SetActive(false);
        }
        else if (obj.tag == "Temple")
        {
            _trainingTemplePanelLeft.SetActive(true);
            _trainingPanelRight.SetActive(true);

            _emptyPanelLeft.SetActive(false);
            _emptyPanelRight.SetActive(false);
        }
    }

    public void Clear()
    {
        _severalSelectionPanelRight.SetActive(false);
        _builderPanelLeft.SetActive(false);
        _builderPanelRight.SetActive(false);
        _trainingBarracksPanelLeft.SetActive(false);
        _trainingResidentialBuildingPanelLeft.SetActive(false);
        _trainingWorkshopPanelLeft.SetActive(false);
        _trainingTemplePanelLeft.SetActive(false);
        _warriorsPanelRight.SetActive(false);
        _healerPanelRight.SetActive(false);
        _trainingPanelRight.SetActive(false);
        _emptyPanelLeft.SetActive(true);
        _emptyPanelRight.SetActive(true);
    }
}
