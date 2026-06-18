namespace UniversalStrategyCore.Faction.AI;

public class DefaultStrategy : IStrategy
{
    public void Apply(AIFaction faction)
    {
         Console.WriteLine($"[DefaultStrategy] Фракция: {faction.Faction.Name} применила DefaultStrategy");
    }
}