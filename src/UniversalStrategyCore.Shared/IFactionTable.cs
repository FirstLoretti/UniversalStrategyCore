namespace UniversalStrategyCore.Shared;

public interface IFactionTable
{
    public FactionTemplate GetFaction(FactionId id);
}