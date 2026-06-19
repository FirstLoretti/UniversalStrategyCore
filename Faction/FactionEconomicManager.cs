using UniversalStrategyCore.Factions;

namespace UniversalStrategyCore.Faction;

public class FactionEconomicManager
{
    public void ApplyTransaction(FactionTemplate faction, EconomicTransaction transaction)
    {
        foreach (var resource in transaction.Amount)
        {
            faction.ResourceAmount[resource.Key] -= resource.Value;
        }
    }
}