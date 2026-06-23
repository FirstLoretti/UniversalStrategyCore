using UniversalStrategyCore.Share;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public interface IFactionProvincesTable
{
    public HashSet<ProvinceTemplate> GetProvinces(FactionTemplate factionTemplate);
}