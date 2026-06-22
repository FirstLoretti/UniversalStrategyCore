using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.EconomicSystem;

namespace UniversalStrategyCore.ConstructionSystem.Logic;

public class ConstructBuildingCommandHandler(
    IFactionEconomicManager economicManager,
    IProvinceConstructionManager constructionManager
) : ICommandHandler<ConstructBuildingCommand>
{
    public Result<IUndoAction> Handle(ConstructBuildingCommand command)
    {
        var factionResources = command.Faction.ResourceAmount;

        foreach (var (resource, cost) in command.ConstructionOrder.Building.Cost)
        {
            if (!factionResources.TryGetValue(resource, out var amount) || amount - cost < 0)
            {
                return Error.NotEnoughtResource(resource);
            }
        }

        EconomicTransactionCommand transaction = new(
            Guid.NewGuid(),
            command.Faction,
            EconomicTransactionType.ConstructBuilding,
            command.ConstructionOrder.Building.Cost,
            DateTime.Now
        );
        economicManager.ApplyTransaction(transaction);
        constructionManager.AddConstructionOrder(command.Province, command.ConstructionOrder);

        return new UndoConstructBuilding(
            constructionManager,
            economicManager,
            command.Province,
            command.ConstructionOrder,
            transaction
        );
    }
}