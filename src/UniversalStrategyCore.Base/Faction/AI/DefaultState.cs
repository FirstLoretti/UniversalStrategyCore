using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Faction.AI;

public class DefaultState : IState
{
    public IStrategy Strategy { get; } = new DefaultStrategy();

    public void Update(AIFaction faction)
    {
        if (faction.Faction.ResourceAmount.TryGetValue(GameResourceType.Gold, out var amountGold))
        {
            if (amountGold > 1500)
            {
                faction.ChangeState(faction.AggressiveState);
                Console.WriteLine($"[DefaultState] Фракция: {faction.Faction.DisplayName} перешла в AgressiveState.");
            }
            else
            {
                Console.WriteLine($"[DefaultState] Фракция: {faction.Faction.DisplayName} осталась в DefaultState.");
            }
        }
        throw new Exception($"[DefaultState] Ресурс: {GameResourceType.Gold} не добавлен в словарь фракции: {faction.Faction.DisplayName}");
    }
}