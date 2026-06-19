using UniversalStrategyCore.ConstructionSystem;
using UniversalStrategyCore.ConstructionSystem.Data;

namespace UniversalStrategyCore.Province.BuildingSystem;

public interface IProvinceBuildingsRegistry
{
    public IReadOnlyList<BuildingTemplate>? GetBuildings(ProvinceTemplate provinceTemplate);
}