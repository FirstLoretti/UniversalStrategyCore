using UniversalStrategyCore.FactionEconomicSystem;

namespace UniversalStrategyCore.Faction.AI;

public class DefaultState : IState
{
    public IStrategy Strategy { get; } = new DefaultStrategy();

    public void Update(AIFaction faction)
    {
        if (faction.Faction.ResourceAmount.TryGetValue(ResourceType.Gold, out var amountGold))
        {
            if (amountGold > 1500)
            {
                faction.ChangeState(faction.AggressiveState);
                Console.WriteLine($"[DefaultState] Фракция: {faction.Faction.Name} перешла в AgressiveState.");
            }
            else
            {
                Console.WriteLine($"[DefaultState] Фракция: {faction.Faction.Name} осталась в DefaultState.");
            }
        }
        throw new Exception($"[DefaultState] Ресурс: {ResourceType.Gold} не добавлен в словарь фракции: {faction.Faction.Name}");
    }
}