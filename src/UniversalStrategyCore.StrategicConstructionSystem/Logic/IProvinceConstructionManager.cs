using UniversalStrategyCore.Shared;
using UniversalStrategyCore.StrategicConstructionSystem.Data;

namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public interface IProvinceConstructionManager
{
    public void OnTurnEnd(ProvinceId id);
    public void AddConstructionOrder(ProvinceId id, ConstructionOrder order);
    public Result<bool> RemoveConstructionOrder(ProvinceId id, ConstructionOrder order);
}