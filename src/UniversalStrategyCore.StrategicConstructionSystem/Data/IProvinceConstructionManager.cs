using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public interface IProvinceConstructionManager
{
    public void OnTurnEnd(ProvinceId id);
    public Result<bool> AddConstructionOrder(ProvinceId id, ConstructionOrder order);
    public Result<bool> RemoveConstructionOrder(ProvinceId id, ConstructionOrder order);
}