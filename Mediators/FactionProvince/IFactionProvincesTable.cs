using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public interface IFactionProvincesTable
{
    public HashSet<ProvinceTemplate> GetProvinces(FactionTemplate factionTemplate);
}