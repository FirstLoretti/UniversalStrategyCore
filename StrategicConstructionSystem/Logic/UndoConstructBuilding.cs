using UniversalStrategyCore.StrategicConstructionSystem.Data;
using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public record UndoConstructBuilding(
    IProvinceConstructionManager ConstructionManager,
    IFactionEconomicManager EconomicManager,
    ProvinceId Id,
    ConstructionOrder Order,
    EconomicTransactionCommand Transaction
) : IUndoAction
{
    public void Undo()
    {
        ConstructionManager.RemoveConstructionOrder(Id, Order);
        EconomicManager.ReturnTransaction(Transaction);
    }

    public void Redo()
    {
        ConstructionManager.AddConstructionOrder(Id, Order);
        EconomicManager.ApplyTransaction(Transaction);
    }
}