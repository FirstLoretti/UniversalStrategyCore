using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public interface IFactionProvincesTable
{
    public HashSet<Shared.Province> GetProvinces(Shared.Faction factionTemplate);
}