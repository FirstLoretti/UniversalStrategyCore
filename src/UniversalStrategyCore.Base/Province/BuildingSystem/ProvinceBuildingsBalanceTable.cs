using UniversalStrategyCore.StrategicConstructionSystem.Data;
using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.ProvinceSystem;

public class ProvinceBuildingsBalanceTable
{
    private readonly Dictionary<BuildingId, Building> _idToBuilding = [];

    public ProvinceBuildingsBalanceTable()
    {
        CreateBuildings();
    }

    public Building GetBuilding(BuildingId id)
    {
        if (_idToBuilding.TryGetValue(id, out var building))
        {
            return building;
        }
        throw new ArgumentException($"[ProvinceBuildingsTable] Здание под id: {id} не найдено");
    }

    private void CreateBuildings()
    {
        Dictionary<GameResourceType, int> farmCost = new()
        {
            {GameResourceType.Gold, 200},
            {GameResourceType.Wood, 100}
        };
        Dictionary<GameResourceType, int> barrackCost = new()
        {
            {GameResourceType.Gold, 400},
            {GameResourceType.Wood, 200}
        };

        AddBuilding(new Building(
            Id: new BuildingId("farm"), DisplayName: "Farm", ConstructionTurns: 1, Cost: farmCost
        ));
        AddBuilding(new Building(
            Id: new BuildingId("barrack"), DisplayName: "Barrack", ConstructionTurns: 2, Cost: barrackCost
        ));
    }

    private void AddBuilding(Building building)
    {
        if (!_idToBuilding.TryAdd(building.Id, building)) { throw new ArgumentException($"Здание: {building} уже есть в таблице"); }
    }
}