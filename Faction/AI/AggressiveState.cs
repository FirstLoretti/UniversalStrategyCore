using UniversalStrategyCore.FactionEconomicSystem;

namespace UniversalStrategyCore.Faction.AI;

public class AggressiveState : IState
{
    public IStrategy Strategy { get; } = new AggressiveStrategy();

    public void Update(AIFaction faction)
    {
        if (faction.Faction.ResourceAmount.TryGetValue(ResourceType.Gold, out var amountGold))
        {
            if (amountGold < 1500)
            {
                faction.ChangeState(faction.DefaultState);
                Console.WriteLine($"[AggressiveState] Фракция: {faction.Faction.Name} перешла в DefaultState.");
            }
            else
            {
                Console.WriteLine($"[AggressiveState] Фракция: {faction.Faction.Name} осталась в AggressiveState.");
            }
        }
        throw new Exception($"[AgressiveState] Ресурс: {ResourceType.Gold} не добавлен в словарь фракции: {faction.Faction.Name}");
    }
}