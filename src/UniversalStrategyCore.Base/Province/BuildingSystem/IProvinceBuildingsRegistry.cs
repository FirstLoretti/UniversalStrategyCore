using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.Province.BuildingSystem;

public interface IProvinceBuildingsRegistry
{
    public IReadOnlyList<Building>? GetBuildings(ProvinceTemplate provinceTemplate);
}