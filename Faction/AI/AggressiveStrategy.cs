namespace UniversalStrategyCore.Faction.AI;

public class AggressiveStrategy : IStrategy
{
    public void Apply(AIFaction faction)
    {
        Console.WriteLine($"[AggressiveStrategy] Фракция: {faction.Faction.Name} применила AggressiveStrategy");
    }
}