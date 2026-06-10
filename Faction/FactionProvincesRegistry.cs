using UniversalStrategyCore.Provinces;

namespace UniversalStrategyCore.Factions;

public class FactionProvincesRegistry
{
    private readonly Dictionary<FactionName, List<ProvinceName>> _factionProvinces = [];

    public FactionProvincesRegistry(IEnumerable<FactionStartingProvinces> factionStartingProvinces)
    {
        foreach(var faction in factionStartingProvinces)
        {
            _factionProvinces.TryAdd(faction.FactionName, faction.ProvinceNames);
            var provincesList = string.Join(",", faction.ProvinceNames);
            Console.WriteLine($"[FactionProvincesRegistry] Фракция: {faction.FactionName} владеет провинциями: {provincesList}");
        }
    }
}