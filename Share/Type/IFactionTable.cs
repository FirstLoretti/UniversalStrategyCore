using UniversalStrategyCore.Factions;

namespace UniversalStrategyCore.Share.Type;

public interface IFactionTable
{
    public FactionTemplate GetFaction(FactionId id);
}