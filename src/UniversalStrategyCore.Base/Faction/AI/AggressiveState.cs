using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Factionn.AI;

public class AggressiveState : IState
{
    public IStrategy Strategy { get; } = new AggressiveStrategy();

    public void Update(AIFaction faction)
    {
        if (faction.Faction.ResourceAmount.TryGetValue(GameResourceType.Gold, out var amountGold))
        {
            if (amountGold < 1500)
            {
                faction.ChangeState(faction.DefaultState);
                Console.WriteLine($"[AggressiveState] Фракция: {faction.Faction.Id} перешла в DefaultState.");
            }
            else
            {
                Console.WriteLine($"[AggressiveState] Фракция: {faction.Faction.DisplayName} осталась в AggressiveState.");
            }
        }
        throw new Exception($"[AgressiveState] Ресурс: {GameResourceType.Gold} не добавлен в словарь фракции: {faction.Faction.DisplayName}");
    }
}