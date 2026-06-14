using UniversalStrategyCore.Faction;
using UniversalStrategyCore.Province;

namespace UniversalStrategyCore.Mediators;

public class FactionProvincesTable
{
    private readonly Dictionary<FactionTemplate, HashSet<ProvinceTemplate>> _factionToProvinces = [];
    private readonly FactionsTable _factionsTable;
    private readonly ProvincesTable _provincesTable;

    public FactionProvincesTable(FactionsTable factionsTable, ProvincesTable provincesTable)
    {
        _factionsTable = factionsTable;
        _provincesTable = provincesTable;
        Initialization();
    }

    public HashSet<ProvinceTemplate> GetProvinces(FactionTemplate factionTemplate)
    {
        if(_factionToProvinces.TryGetValue(factionTemplate, out var provinces))
        {
            return provinces;
        }
        throw new ArgumentException($"[FactionProvincesTable] Фракция {factionTemplate.Name} не найдена в таблице _factionToProvinces");
    }

    private void Initialization()
    {
        SetStartingProvinces();
    }

    private void SetStartingProvinces()
    {
        var england = _factionsTable.GetFaction(FactionName.England);
        HashSet<ProvinceTemplate> englandProvinces =
        [
            _provincesTable.GetProvince(ProvinceName.London)
        ];

        var france = _factionsTable.GetFaction(FactionName.France);
        HashSet<ProvinceTemplate> franceProvinces =
        [
            _provincesTable.GetProvince(ProvinceName.Paris)
        ];

        AddProvince(england, englandProvinces);
        AddProvince(france, franceProvinces);
    }

    private void AddProvince(FactionTemplate factionTemplate, HashSet<ProvinceTemplate> provinceTemplates)
    {
        if (!_factionToProvinces.TryGetValue(factionTemplate, out var provinces))
        {
            provinces = [];
            _factionToProvinces.Add(factionTemplate, provinces);
        }
        provinces.UnionWith(provinceTemplates);
    }
}