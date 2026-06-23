using UniversalStrategyCore.StrategicConstructionSystem.Data;
using UniversalStrategyCore.EconomicSystem;
using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public class ConstructBuildingCommandHandler(
    IFactionEconomicManager economicManager,
    IProvinceConstructionManager constructionManager,
    IFactionTable factionTable
) : ICommandHandler<ConstructBuildingCommand>
{
    public Result<IUndoAction> Handle(ConstructBuildingCommand command)
    {
        var factionResources = factionTable.GetFaction(command.FactionId).ResourceAmount;

        foreach (var (resource, cost) in command.ConstructionOrder.Building.Cost)
        {
            if (!factionResources.TryGetValue(resource, out var amount) || amount - cost < 0)
            {
                return Error.NotEnoughtResource(resource);
            }
        }

        EconomicTransactionCommand transaction = new(
            Guid.NewGuid(),
            command.FactionId,
            EconomicTransactionType.ConstructBuilding,
            command.ConstructionOrder.Building.Cost,
            DateTime.Now
        );
        economicManager.ApplyTransaction(transaction);
        constructionManager.AddConstructionOrder(command.ProvinceId, command.ConstructionOrder);

        return new UndoConstructBuilding(
            constructionManager,
            economicManager,
            command.ProvinceId,
            command.ConstructionOrder,
            transaction
        );
    }
}