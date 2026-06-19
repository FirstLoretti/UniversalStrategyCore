using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.FactionEconomicSystem;

namespace UniversalStrategyCore.ConstructionSystem.Logic;

public class StrategicalConstructionManager(
    FactionEconomicManager factionEconomicManager,
    IProvinceConstructionManager provinceConstructionManager
)
{
    public Result<ConstructionOrder> ConstructBuilding(ConstructBuildingCommand command)
    {
        var result = CanConstructBuilding(command);
        if (result.IsSuccess)
        {
            EconomicTransaction transaction = new(
                Guid.NewGuid(),
                command.Faction,
                EconomicTransactionType.ConstructBuilding,
                command.Building.Cost,
                DateTime.Now
            );
            factionEconomicManager.ApplyTransaction(command.Faction, transaction);
            ConstructionOrder constructionOrder = new(command.Building);
            provinceConstructionManager.AddConstructionOrder(command.Province, constructionOrder);
            return constructionOrder;
        }
        else
        {
            Console.WriteLine(result.Error);
            return result.Error!;
        }
    }

    private Result<bool> CanConstructBuilding(ConstructBuildingCommand command)
    {
        var factionResources = command.Faction.ResourceAmount;

        foreach (var (resource, cost) in command.Building.Cost)
        {
            if (!factionResources.TryGetValue(resource, out var amount) || amount - cost < 0)
            {
                return Error.NotEnoughtResource(resource);
            }
        }
        return true;
    }
}