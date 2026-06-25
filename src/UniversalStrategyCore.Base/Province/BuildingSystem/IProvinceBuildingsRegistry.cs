using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.ProvinceSystem.BuildingSystem;

public interface IProvinceBuildingsRegistry
{
    public IReadOnlyList<Building>? GetBuildings(Shared.Province provinceTemplate);
}