using UniversalStrategyCore.ConstructionSystem.Data;
using UniversalStrategyCore.Faction;

namespace UniversalStrategyCore.ConstructionSystem.Logic;

public class StrategicalConstructionManager(
    FactionEconomicManager factionEconomicManager,
    IProvinceConstructionManager provinceConstructionManager
)
{
    public Result<BuildingTemplate> ConstructBuilding(ConstructBuildingCommand command)
    {
        if (CanConstructBuilding(command))
        {
            EconomicTransaction transaction = new(
                Guid.NewGuid(),
                command.Faction,
                EconomicTransactionType.ConstructBuilding,
                command.Building.Cost,
                DateTime.Now
            );
            factionEconomicManager.ApplyTransaction(command.Faction, transaction);
            provinceConstructionManager.AddConstructionOrder(command.Province, new ConstructionOrder(command.Building));
            return command.Building;
        }
        else
        {
            Console.WriteLine($"[StrategicalConstructionManager] Недостаточно ресурсов для строительства {command.Building.DisplayName}");
            return ErrorType.NotEnoughtResource;
        }
    }

    private bool CanConstructBuilding(ConstructBuildingCommand command)
    {
        var factionResources = command.Faction.ResourceAmount;

        foreach (var (resource, cost) in command.Building.Cost)
        {
            if (!factionResources.TryGetValue(resource, out var amount) || amount - cost < 0) { return false; }
        }
        return true;
    }
}