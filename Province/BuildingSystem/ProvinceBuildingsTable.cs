namespace UniversalStrategyCore.Province.BuildingSystem;

public class ProvinceBuildingsTable
{
    private readonly Dictionary<BuildingLogicType, List<BuildingTemplate>> _logicTypeToBuildings = [];
    private readonly Dictionary<string, BuildingTemplate> _idToBuilding = [];

    public ProvinceBuildingsTable()
    {
        Initialize();
    }

    public BuildingTemplate GetBuilding(string id)
    {
        if (_idToBuilding.TryGetValue(id, out var building))
        {
            return building;
        }
        throw new ArgumentException($"[ProvinceBuildingsTable] Здание под id: {id} не найдено в _idToBuilding.");
    }

    private void Initialize()
    {
        AddBuilding(BuildingLogicType.Economic, new BuildingTemplate(
            Id: "farm_1", DisplayName: "Farm", ConstructionTurns: 1, WoodCost: 100
            ));
        AddBuilding(BuildingLogicType.Military, new BuildingTemplate(
            Id: "barrack_1", DisplayName: "Barrack", ConstructionTurns: 2, WoodCost: 300
            ));
    }

    private void AddBuilding(BuildingLogicType buildingLogicType, BuildingTemplate buildingTemplate)
    {
        if (!_logicTypeToBuildings.TryGetValue(buildingLogicType, out var buildingTemplates))
        {
            buildingTemplates = [];
            _logicTypeToBuildings.Add(buildingLogicType, buildingTemplates);
        }
        buildingTemplates.Add(buildingTemplate);

        _idToBuilding.Add(buildingTemplate.Id, buildingTemplate);
    }
}