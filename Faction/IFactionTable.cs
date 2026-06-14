namespace UniversalStrategyCore.Faction;

public interface IFactionTable
{
    public FactionTemplate GetFaction(FactionName factionName);
}