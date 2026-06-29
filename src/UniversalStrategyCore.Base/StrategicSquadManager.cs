using UniversalStrategyCore.EconomicSystem;

namespace UniversalStrategyCore;

public class StrategicSquadManager(IFactionEconomicManager factionEconomicManager)
{
    private readonly Dictionary<int, StrategicSquad> _idToSquad = [];

    public void OnTurnEnd()
    {
        foreach(var pair in _idToSquad)
        {
            var squad = pair.Value;
            var transaction = new EconomicTransactionCommand(
                Guid.NewGuid(), squad.HolderFaction, EconomicTransactionType.SquadUpkeep,
                squad.GetUpkeep(), DateTime.Now
            );

            var result = factionEconomicManager.ApplyTransaction(transaction);
            if(result.IsSuccess) pair.Value.ReplenishmentUnits();
            else pair.Value.NonCombatLosses();
        }
    }
}