namespace UniversalStrategyCore.Factions;

public class FactionManager
{
    public Dictionary<string, FactionName> playerFactionPairs = [];

    public void RegisterFaction(string holderName, FactionName factionName)
    {
        playerFactionPairs.TryAdd(holderName, factionName);
        Console.WriteLine($"[FactionManager] Игрок: {holderName} выбрал фракцию: {factionName}");
    }
}