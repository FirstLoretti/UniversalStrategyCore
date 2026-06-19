namespace UniversalStrategyCore.Factions;

public interface IFactionTable
{
    public FactionTemplate GetFaction(FactionName factionName);
}