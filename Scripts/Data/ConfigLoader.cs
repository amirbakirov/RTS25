using System.Collections.Generic;
using UnityEngine;

public class ConfigLoader : MonoBehaviour
{
    [SerializeField] private XMLController _xmlController;

    private ArcherConfig _archerConfig;
    private BarracksConfig _barracksConfig;
    private BedsConfig _bedsConfig;
    private BuilderConfig _builderConfig;
    private CatapultConfig _catapultConfig;
    private HealerConfig _healerConfig;
    private HeavyWarriorConfig _heavyWarriorConfig;
    private MillConfig _millConfig;
    private ResidentialBuildingConfig _residentialBuildingConfig;
    private SiegeTowerConfig _siegeTowerConfig;
    private SmelterConfig _smelterConfig;
    private SpearmanConfig _spearmanConfig;
    private StorageConfig _storageConfig;
    private TempleConfig _templeConfig;
    private TownHallConfig _townHallConfig;
    private WatchtowerConfig _watchtowerConfig;
    private WorkshopConfig _workshopConfig;

    private void Start()
    {
        _archerConfig = Resources.Load<ArcherConfig>("ArcherConfig");
        _barracksConfig = Resources.Load<BarracksConfig>("BarracksConfig");
        _bedsConfig = Resources.Load<BedsConfig>("BedsConfig");
        _builderConfig = Resources.Load<BuilderConfig>("BuilderConfig");
        _catapultConfig = Resources.Load<CatapultConfig>("CatapultConfig");
        _healerConfig = Resources.Load<HealerConfig>("HealerConfig");
        _heavyWarriorConfig = Resources.Load<HeavyWarriorConfig>("HeavyWarriorConfig");
        _millConfig = Resources.Load<MillConfig>("MillConfig");
        _residentialBuildingConfig = Resources.Load<ResidentialBuildingConfig>("ResidentialBuildingConfig");
        _siegeTowerConfig = Resources.Load<SiegeTowerConfig>("SiegeTowerConfig");
        _smelterConfig = Resources.Load<SmelterConfig>("SmelterConfig");
        _spearmanConfig = Resources.Load<SpearmanConfig>("SpearmanConfig");
        _storageConfig = Resources.Load<StorageConfig>("StorageConfig");
        _templeConfig = Resources.Load<TempleConfig>("TempleConfig");
        _townHallConfig = Resources.Load<TownHallConfig>("TownHallConfig");
        _watchtowerConfig = Resources.Load<WatchtowerConfig>("WatchtowerConfig");
        _workshopConfig = Resources.Load<WorkshopConfig>("WorkshopConfig");

        WriteUnits();
        WriteBuildings();
    }

    private void WriteUnits()
    {
        List<string> info = _xmlController.GetUnitInfo("Archer");
        _archerConfig.unit_name = info[0];
        _archerConfig.moveSpeed = int.Parse(info[1]);
        _archerConfig.health = int.Parse(info[2]);
        _archerConfig.trainingResource = info[3];
        _archerConfig.trainingResourceCount = int.Parse(info[4]);
        _archerConfig.visionZone = int.Parse(info[5]);
        _archerConfig.minAttackDistance = int.Parse(info[6]);
        _archerConfig.maxAttackDistance = int.Parse(info[7]);
        _archerConfig.attackDelay = int.Parse(info[8]);
        _archerConfig.damage = int.Parse(info[9]);


        info = _xmlController.GetUnitInfo("Catapult");
        _catapultConfig.unit_name = info[0];
        _catapultConfig.moveSpeed = int.Parse(info[1]);
        _catapultConfig.health = int.Parse(info[2]);
        _catapultConfig.trainingResource = info[3];
        _catapultConfig.trainingResourceCount = int.Parse(info[4]);
        _catapultConfig.visionZone = int.Parse(info[5]);
        _catapultConfig.minAttackDistance = int.Parse(info[6]);
        _catapultConfig.maxAttackDistance = int.Parse(info[7]);
        _catapultConfig.attackDelay = int.Parse(info[8]);
        _catapultConfig.damage = int.Parse(info[9]);


        info = _xmlController.GetUnitInfo("HeavyWarrior");
        _heavyWarriorConfig.unit_name = info[0];
        _heavyWarriorConfig.moveSpeed = int.Parse(info[1]);
        _heavyWarriorConfig.health = int.Parse(info[2]);
        _heavyWarriorConfig.trainingResource = info[3];
        _heavyWarriorConfig.trainingResourceCount = int.Parse(info[4]);
        _heavyWarriorConfig.visionZone = int.Parse(info[5]);
        _heavyWarriorConfig.minAttackDistance = int.Parse(info[6]);
        _heavyWarriorConfig.maxAttackDistance = int.Parse(info[7]);
        _heavyWarriorConfig.attackDelay = int.Parse(info[8]);
        _heavyWarriorConfig.damage = int.Parse(info[9]);


        info = _xmlController.GetUnitInfo("Spearman");
        _spearmanConfig.unit_name = info[0];
        _spearmanConfig.moveSpeed = int.Parse(info[1]);
        _spearmanConfig.health = int.Parse(info[2]);
        _spearmanConfig.trainingResource = info[3];
        _spearmanConfig.trainingResourceCount = int.Parse(info[4]);
        _spearmanConfig.visionZone = int.Parse(info[5]);
        _spearmanConfig.minAttackDistance = int.Parse(info[6]);
        _spearmanConfig.maxAttackDistance = int.Parse(info[7]);
        _spearmanConfig.attackDelay = int.Parse(info[8]);
        _spearmanConfig.damage = int.Parse(info[9]);


        info = _xmlController.GetUnitInfo("Builder");
        _builderConfig.unit_name = info[0];
        _builderConfig.moveSpeed = int.Parse(info[1]);
        _builderConfig.health = int.Parse(info[2]);
        _builderConfig.trainingResource = info[3];
        _builderConfig.trainingResourceCount = int.Parse(info[4]);
        _builderConfig.visionZone = int.Parse(info[5]);
        _builderConfig.extractionTime = int.Parse(info[6]);
        _builderConfig.repairTime = int.Parse(info[7]);
        _builderConfig.repairEfficiency = int.Parse(info[8]);


        info = _xmlController.GetUnitInfo("Healer");
        _healerConfig.unit_name = info[0];
        _healerConfig.moveSpeed = int.Parse(info[1]);
        _healerConfig.health = int.Parse(info[2]);
        _healerConfig.trainingResource = info[3];
        _healerConfig.trainingResourceCount = int.Parse(info[4]);
        _healerConfig.visionZone = int.Parse(info[5]);
        _healerConfig.minHealDistance = int.Parse(info[6]);
        _healerConfig.maxHealDistance = int.Parse(info[7]);
        _healerConfig.healDelay = int.Parse(info[8]);
        _healerConfig.heal = int.Parse(info[9]);


        info = _xmlController.GetUnitInfo("SiegeTower");
        _siegeTowerConfig.unit_name = info[0];
        _siegeTowerConfig.moveSpeed = int.Parse(info[1]);
        _siegeTowerConfig.health = int.Parse(info[2]);
        _siegeTowerConfig.trainingResource = info[3];
        _siegeTowerConfig.trainingResourceCount = int.Parse(info[4]);
        _siegeTowerConfig.visionZone = int.Parse(info[5]);
        _siegeTowerConfig.minAttackDistance = int.Parse(info[6]);
        _siegeTowerConfig.maxAttackDistance = int.Parse(info[7]);
        _siegeTowerConfig.attackDelay = int.Parse(info[8]);
        _siegeTowerConfig.damage = int.Parse(info[9]);
        _siegeTowerConfig.capacity = int.Parse(info[9]);
    }

    private void WriteBuildings()
    {
        List<string> info = _xmlController.GetBuildingInfo("Barracks");
        _barracksConfig.strength = int.Parse(info[0]);
        _barracksConfig.buildResource = info[1];
        _barracksConfig.buildResourceCount = int.Parse(info[2]);
        _barracksConfig.unit1 = info[3];
        _barracksConfig.unit2 = info[4];
        _barracksConfig.unit3 = info[5];


        info = _xmlController.GetBuildingInfo("ResidentialBuilding");
        _residentialBuildingConfig.strength = int.Parse(info[0]);
        _residentialBuildingConfig.buildResource = info[1];
        _residentialBuildingConfig.buildResourceCount = int.Parse(info[2]);
        _residentialBuildingConfig.unit1 = info[3];


        info = _xmlController.GetBuildingInfo("Workshop");
        _workshopConfig.strength = int.Parse(info[0]);
        _workshopConfig.buildResource = info[1];
        _workshopConfig.buildResourceCount = int.Parse(info[2]);
        _workshopConfig.unit1 = info[3];
        _workshopConfig.unit2 = info[4];


        info = _xmlController.GetBuildingInfo("Temple");
        _templeConfig.strength = int.Parse(info[0]);
        _templeConfig.buildResource = info[1];
        _templeConfig.buildResourceCount = int.Parse(info[2]);
        _templeConfig.unit1 = info[3];


        info = _xmlController.GetBuildingInfo("Beds");
        _bedsConfig.strength = int.Parse(info[0]);
        _bedsConfig.buildResource = info[1];
        _bedsConfig.buildResourceCount = int.Parse(info[2]);
        _bedsConfig.resource = info[3];


        info = _xmlController.GetBuildingInfo("Mill");
        _millConfig.strength = int.Parse(info[0]);
        _millConfig.buildResource = info[1];
        _millConfig.buildResourceCount = int.Parse(info[2]);
        _millConfig.resource = info[3];


        info = _xmlController.GetBuildingInfo("Watchtower");
        _watchtowerConfig.strength = int.Parse(info[0]);
        _watchtowerConfig.buildResource = info[1];
        _watchtowerConfig.buildResourceCount = int.Parse(info[2]);
        _watchtowerConfig.enemyDetectionRadius = int.Parse(info[3]);
        _watchtowerConfig.buildingAreaRadius = int.Parse(info[4]);
        _watchtowerConfig.archerCapacity = int.Parse(info[5]);
        _watchtowerConfig.minAttackDistance = int.Parse(info[6]);
        _watchtowerConfig.maxAttackDistance = int.Parse(info[7]);
        _watchtowerConfig.attackDelay = int.Parse(info[8]);
        _watchtowerConfig.damage = int.Parse(info[9]);


        info = _xmlController.GetBuildingInfo("Storage");
        _storageConfig.strength = int.Parse(info[0]);
        _storageConfig.buildResource = info[1];
        _storageConfig.buildResourceCount = int.Parse(info[2]);
        _storageConfig.storageLimitIncrease = int.Parse(info[3]);


        info = _xmlController.GetBuildingInfo("TownHall");
        _townHallConfig.strength = int.Parse(info[0]);
        _townHallConfig.buildResource = info[1];
        _townHallConfig.buildResourceCount = int.Parse(info[2]);
        _townHallConfig.buildingAreaRadius = int.Parse(info[3]);


        info = _xmlController.GetBuildingInfo("Smelter");
        _smelterConfig.strength = int.Parse(info[0]);
        _smelterConfig.buildResource = info[1];
        _smelterConfig.buildResourceCount = int.Parse(info[2]);
        _smelterConfig.resource = info[3];
    }
}
