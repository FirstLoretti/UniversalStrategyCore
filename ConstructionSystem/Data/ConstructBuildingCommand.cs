using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.ConstructionSystem.Data;

public record ConstructBuildingCommand(
    FactionTemplate Faction,
    ProvinceTemplate Province,
    BuildingTemplate Building
);