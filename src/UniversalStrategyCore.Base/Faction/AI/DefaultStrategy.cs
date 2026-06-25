namespace UniversalStrategyCore.Factionn.AI;

public class DefaultStrategy : IStrategy
{
    public void Apply(AIFaction faction)
    {
         Console.WriteLine($"[DefaultStrategy] Фракция: {faction.Faction.DisplayName} применила DefaultStrategy");
    }
}