using UniversalStrategyCore.StrategicConstructionSystem;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.Province.BuildingSystem;

public interface IProvinceBuildingsRegistry
{
    public IReadOnlyList<BuildingTemplate>? GetBuildings(ProvinceTemplate provinceTemplate);
}