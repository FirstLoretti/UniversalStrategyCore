using UniversalStrategyCore.Factions;
using UniversalStrategyCore.Province;
using UniversalStrategyCore.Share.Type;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class FactionProvincesTable: IFactionProvincesTable
{
    private readonly Dictionary<FactionTemplate, HashSet<ProvinceTemplate>> _factionToProvinces = [];
    private readonly IFactionTable _factionTable;
    private readonly IProvinceTable _provinceTable;

    public FactionProvincesTable(IFactionTable factionTable, IProvinceTable provinceTable)
    {
        _factionTable = factionTable;
        _provinceTable = provinceTable;
        Initialization();
    }

    public HashSet<ProvinceTemplate> GetProvinces(FactionTemplate factionTemplate)
    {
        if(_factionToProvinces.TryGetValue(factionTemplate, out var provinces))
        {
            return provinces;
        }
        throw new ArgumentException($"[FactionProvincesTable] Фракция {factionTemplate.Id} не найдена в таблице _factionToProvinces");
    }

    private void Initialization()
    {
        SetStartingProvinces();
    }

    private void SetStartingProvinces()
    {
        var england = _factionTable.GetFaction("england");
        HashSet<ProvinceTemplate> englandProvinces =
        [
            _provinceTable.GetProvince("london")
        ];

        var france = _factionTable.GetFaction("france");
        HashSet<ProvinceTemplate> franceProvinces =
        [
            _provinceTable.GetProvince("paris")
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