using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.ConstructionSystem.Logic;

public record UndoConstructBuilding(
    IProvinceConstructionManager ConstructionManager,
    IFactionEconomicManager EconomicManager,
    ProvinceTemplate Province,
    ConstructionOrder Order,
    EconomicTransactionCommand Transaction
) : IUndoAction
{
    public void Undo()
    {
        ConstructionManager.RemoveConstructionOrder(Province, Order);
        EconomicManager.ReturnTransaction(Transaction);
    }

    public void Redo()
    {
        ConstructionManager.AddConstructionOrder(Province, Order);
        EconomicManager.ApplyTransaction(Transaction);
    }
}