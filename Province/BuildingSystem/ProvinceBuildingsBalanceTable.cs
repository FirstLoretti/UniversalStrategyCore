using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.EconomicSystem;

namespace UniversalStrategyCore.Province;

public class ProvinceBuildingsBalanceTable
{
    private readonly Dictionary<BuildingLogicType, List<BuildingTemplate>> _logicTypeToBuildings = [];
    private readonly Dictionary<string, BuildingTemplate> _idToBuilding = [];

    public ProvinceBuildingsBalanceTable()
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
        Dictionary<GameResourceType, int> farm_1Cost = new()
        {
            {GameResourceType.Gold, 200},
            {GameResourceType.Wood, 100}
        };
        Dictionary<GameResourceType, int> barrack_1Cost = new()
        {
            {GameResourceType.Gold, 400},
            {GameResourceType.Wood, 200}
        };

        AddBuilding(BuildingLogicType.Economic, new BuildingTemplate(
            Id: "farm_1", DisplayName: "Farm", ConstructionTurns: 1, farm_1Cost
            ));
        AddBuilding(BuildingLogicType.Military, new BuildingTemplate(
            Id: "barrack_1", DisplayName: "Barrack", ConstructionTurns: 2, barrack_1Cost
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