using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLController : MonoBehaviour
{
    private static readonly string _filepath = @"C:\Users\user\Unity projects\RTS 2025\Assets\Data\Data.xml";

    private void Awake()
    {
		XmlDocument xmlDoc = new XmlDocument();
		try
		{
			xmlDoc.Load( _filepath );
		}
		catch (System.Exception)
		{
			XmlElement head = xmlDoc.CreateElement( "DataBase" );
			xmlDoc.AppendChild( head );

            head.AppendChild(WriteUnits(xmlDoc));

            head.AppendChild(WriteBuildings(xmlDoc));

            head.AppendChild(WriteSettings(xmlDoc));

            head.AppendChild(WriteGameSettings(xmlDoc));

            xmlDoc.Save( _filepath );

        }
    }

	private XmlElement WriteUnits(XmlDocument xmlDoc)
    {
        XmlElement units = xmlDoc.CreateElement("Units");

        XmlElement node = xmlDoc.CreateElement("Archer");
        XmlElement newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "Archer";
        node.AppendChild( newNode );
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "5";
        node.AppendChild( newNode );
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "7";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("wood", "10");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "10";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinAttackDistance");
        newNode.InnerText = "0";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxAttackDistance");
        newNode.InnerText = "10";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("AttackDelay");
        newNode.InnerText = "1";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Damage");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        units.AppendChild(node);


        node = xmlDoc.CreateElement("Catapult");
        newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "Catapult";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "3";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "20";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("stone", "15");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "12";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinAttackDistance");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxAttackDistance");
        newNode.InnerText = "12";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("AttackDelay");
        newNode.InnerText = "3";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Damage");
        newNode.InnerText = "8";
        node.AppendChild(newNode);
        units.AppendChild(node);


        node = xmlDoc.CreateElement("HeavyWarrior");
        newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "HeavyWarrior";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "1";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "15";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("wood", "20");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinAttackDistance");
        newNode.InnerText = "0";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxAttackDistance");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("AttackDelay");
        newNode.InnerText = "3";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Damage");
        newNode.InnerText = "7";
        node.AppendChild(newNode);
        units.AppendChild(node);


        node = xmlDoc.CreateElement("Spearman");
        newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "Spearman";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "7";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("wood", "10");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "7";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinAttackDistance");
        newNode.InnerText = "0";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxAttackDistance");
        newNode.InnerText = "1";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("AttackDelay");
        newNode.InnerText = "1";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Damage");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        units.AppendChild(node);


        node = xmlDoc.CreateElement("Builder");
        newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "Builder";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "7";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("wood", "15");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("ExtractionTime");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("RepairTime");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("RepairEfficiency");
        newNode.InnerText = "1";
        node.AppendChild(newNode);
        units.AppendChild(node);


        node = xmlDoc.CreateElement("Healer");
        newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "Healer";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "7";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("wood", "25");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinHealDistance");
        newNode.InnerText = "0";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxHealDistance");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("HealDelay");
        newNode.InnerText = "3";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Heal");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        units.AppendChild(node);


        node = xmlDoc.CreateElement("SiegeTower");
        newNode = xmlDoc.CreateElement("Name");
        newNode.InnerText = "SiegeTower";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MoveSpeed");
        newNode.InnerText = "1";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Health");
        newNode.InnerText = "20";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("TrainingCost");
        newNode.SetAttribute("stone", "30");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("VisionZone");
        newNode.InnerText = "8";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinAttackDistance");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxAttackDistance");
        newNode.InnerText = "8";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("AttackDelay");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Damage");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Capacity");
        newNode.InnerText = "10";
        node.AppendChild(newNode);
        units.AppendChild(node);

        return units;
    }

    private XmlElement WriteBuildings(XmlDocument xmlDoc)
    {
        XmlElement buildings = xmlDoc.CreateElement("Buildings");

        XmlElement node = xmlDoc.CreateElement("Barracks");
        XmlElement newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "150";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("wood", "100");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("UnitTraining");
        newNode.SetAttribute("unit1", "Archer");
        newNode.SetAttribute("unit2", "Spearman");
        newNode.SetAttribute("unit3", "HeavyWarrior");
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("ResidentialBuilding");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "300";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("wood", "250");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("UnitTraining");
        newNode.SetAttribute("unit1", "Builder");
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Workshop");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "400";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("stone", "200");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("UnitTraining");
        newNode.SetAttribute("unit1", "Catapult");
        newNode.SetAttribute("unit2", "SiegeTower");
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Temple");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "500";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("stone", "250");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("UnitTraining");
        newNode.SetAttribute("unit1", "Healer");
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Beds");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "300";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("wood", "500");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("ResourceProduction");
        newNode.SetAttribute("resource", "seed");
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Mill");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "500";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("stone", "300");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("ResourceProduction");
        newNode.SetAttribute("resource", "food");
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Watchtower");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "700";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("metal", "150");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("EnemyDetectionRadius");
        newNode.InnerText = "20";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildingAreaRadius");
        newNode.InnerText = "10";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("ArcherCapacity");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MinAttackDistance");
        newNode.InnerText = "0";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("MaxAttackDistance");
        newNode.InnerText = "8";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("AttackDelay");
        newNode.InnerText = "2";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("Damage");
        newNode.InnerText = "5";
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Storage");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "1000";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("stone", "300");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("StorageLimitIncrease");
        newNode.InnerText = "100";
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("TownHall");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "3000";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("stone", "500");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildingAreaRadius");
        newNode.InnerText = "15";
        node.AppendChild(newNode);
        buildings.AppendChild(node);


        node = xmlDoc.CreateElement("Smelter");
        newNode = xmlDoc.CreateElement("Strength");
        newNode.InnerText = "500";
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("BuildCost");
        newNode.SetAttribute("stone", "300");
        node.AppendChild(newNode);
        newNode = xmlDoc.CreateElement("ResourceProduction");
        newNode.SetAttribute("resource", "metal");
        node.AppendChild(newNode);
        buildings.AppendChild(node);



        return buildings;
    }

    private XmlElement WriteSettings(XmlDocument xmlDoc)
    {
        XmlElement settings = xmlDoc.CreateElement("Settings");

        XmlElement node = xmlDoc.CreateElement("WindowSize");
        node.InnerText = "1280:720";
        settings.AppendChild(node);
        node = xmlDoc.CreateElement("WindowMode");
        node.InnerText = "ON";
        settings.AppendChild(node);
        node = xmlDoc.CreateElement("SoundsAndMusic");
        node.InnerText = "ON";
        settings.AppendChild(node);
        node = xmlDoc.CreateElement("Volume");
        node.InnerText = "100";
        settings.AppendChild(node);


        return settings;
    }

    private XmlElement WriteGameSettings(XmlDocument xmlDoc)
    {
        XmlElement settings = xmlDoc.CreateElement("GameSettings");

        XmlElement node = xmlDoc.CreateElement("Difficulties");
        XmlElement newNode = xmlDoc.CreateElement("Easy");
        XmlElement helpNode = xmlDoc.CreateElement("EnemySpawnTime");
        helpNode.InnerText = "15";
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("EnemyUnitSpawn");
        helpNode.SetAttribute("unit1", "Spearman");
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("ArmyLimit");
        helpNode.InnerText = "5";
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("ArmyLimitIncrease");
        helpNode.InnerText = "2";
        newNode.AppendChild(helpNode);
        node.AppendChild(newNode);

        newNode = xmlDoc.CreateElement("Middle");
        helpNode = xmlDoc.CreateElement("EnemySpawnTime");
        helpNode.InnerText = "10";
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("EnemyUnitSpawn");
        helpNode.SetAttribute("unit1", "Spearman");
        helpNode.SetAttribute("unit2", "Archer");
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("ArmyLimit");
        helpNode.InnerText = "8";
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("ArmyLimitIncrease");
        helpNode.InnerText = "4";
        newNode.AppendChild(helpNode);
        node.AppendChild(newNode);

        newNode = xmlDoc.CreateElement("Difficult");
        helpNode = xmlDoc.CreateElement("EnemySpawnTime");
        helpNode.InnerText = "15";
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("EnemyUnitSpawn");
        helpNode.SetAttribute("unit1", "Spearman");
        helpNode.SetAttribute("unit2", "Archer");
        helpNode.SetAttribute("unit3", "Catapult");
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("ArmyLimit");
        helpNode.InnerText = "10";
        newNode.AppendChild(helpNode);
        helpNode = xmlDoc.CreateElement("ArmyLimitIncrease");
        helpNode.InnerText = "5";
        newNode.AppendChild(helpNode);
        node.AppendChild(newNode);

        settings.AppendChild(node);

        node = xmlDoc.CreateElement("FreeZoneRadius");
        node.InnerText = "10";
        settings.AppendChild(node);


        return settings;
    }

    public List<string> GetUnitInfo(string unitName)
    {
        List<string> info = new List<string>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_filepath);

        XmlNode unit = xmlDoc.SelectSingleNode("DataBase").SelectSingleNode("Units").SelectSingleNode(unitName);

        foreach (XmlNode node in unit.ChildNodes)
        {
            if (node.Attributes.Count == 0)
            {
                info.Add(node.InnerText);
            }
            else
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    info.Add(attr.Name);
                    info.Add(attr.Value);
                }
            }
        }

        return info;
    }

    public List<string> GetBuildingInfo(string buildingName)
    {
        List<string> info = new List<string>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_filepath);

        XmlNode buildings = xmlDoc.SelectSingleNode("DataBase").SelectSingleNode("Buildings").SelectSingleNode(buildingName);

        foreach (XmlNode node in buildings.ChildNodes)
        {
            if (node.Attributes.Count == 0)
            {
                info.Add(node.InnerText);
            }
            else
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    if (!(attr.Name.StartsWith('u') ||
                        attr.Name.StartsWith('r')))
                    {
                        info.Add(attr.Name);
                    }
                    info.Add(attr.Value);
                }
            }
        }

        return info;
    }

    public bool CheckSettings(string windowSize, bool windowMode, bool soundsAndMusic, int volume)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_filepath);

        string windowModeText = "OFF";
        string soundsAndMusicText = "OFF";
        if (windowMode)
            windowModeText = "ON";
        if (soundsAndMusic)
            soundsAndMusicText = "ON";

        XmlNode node = xmlDoc.SelectSingleNode("DataBase").SelectSingleNode("Settings");

        if (node.SelectSingleNode("WindowSize").InnerText != windowSize ||
            node.SelectSingleNode("WindowMode").InnerText != windowModeText ||
            node.SelectSingleNode("SoundsAndMusic").InnerText != soundsAndMusicText ||
            node.SelectSingleNode("Volume").InnerText != volume.ToString())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    public void UpdateSettings(string windowSize, bool windowMode, bool soundsAndMusic, int volume)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_filepath);

        string windowModeText = "OFF";
        string soundsAndMusicText = "OFF";
        if (windowMode)
            windowModeText = "ON";
        if (soundsAndMusic)
            soundsAndMusicText = "ON";

        XmlNode node = xmlDoc.SelectSingleNode("DataBase").SelectSingleNode("Settings");

        node.SelectSingleNode("WindowSize").InnerText = windowSize;
        node.SelectSingleNode("WindowMode").InnerText = windowModeText;
        node.SelectSingleNode("SoundsAndMusic").InnerText = soundsAndMusicText;
        node.SelectSingleNode("Volume").InnerText = volume.ToString();

        xmlDoc.Save(_filepath);
    }

    public List<string> GetSettings()
    {
        List<string> settings = new List<string>();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_filepath);

        XmlNode node = xmlDoc.SelectSingleNode("DataBase").SelectSingleNode("Settings");

        settings.Add(node.SelectSingleNode("WindowSize").InnerText);
        settings.Add(node.SelectSingleNode("WindowMode").InnerText);
        settings.Add(node.SelectSingleNode("SoundsAndMusic").InnerText);
        settings.Add(node.SelectSingleNode("Volume").InnerText);

        return settings;
    }

    public int GetFreeZoneRadius()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(_filepath);

        XmlNode node = xmlDoc.SelectSingleNode("DataBase").SelectSingleNode("GameSettings").SelectSingleNode("FreeZoneRadius");

        return int.Parse(node.InnerText);
    }
}
