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
        Dictionary<GameResourceType, int> deficitResources = [];

        foreach (var (resource, cost) in command.ConstructionOrder.Building.Cost)
        {
            if (!factionResources.TryGetValue(resource, out var amount))
            {
                return Error.NotFound(resource, nameof(factionResources));
            }
            var operaion = amount - cost;
            if (operaion < 0) deficitResources.Add(resource, int.Abs(operaion));
        }

        if (deficitResources.Count > 0) return Error.NotEnoughtResources(deficitResources);

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