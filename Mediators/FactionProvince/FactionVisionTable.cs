using UniversalStrategyCore.Share;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class FactionVisionTable
{
    public IReadOnlyDictionary<FactionTemplate, HashSet<FactionTemplate>> VisionContact => _visionContact;
    public IReadOnlyDictionary<FactionTemplate, HashSet<ProvinceTemplate>> VisibleProvinces => _visibleProvinces;

    private readonly Dictionary<FactionTemplate, HashSet<FactionTemplate>> _visionContact = [];
    private readonly Dictionary<FactionTemplate, HashSet<ProvinceTemplate>> _visibleProvinces = [];
    private readonly IFactionTable _factionTable;
    private readonly IFactionProvincesTable _factionProvincesTable;

    public FactionVisionTable(IFactionTable factionTable, IFactionProvincesTable factionProvincesTable)
    {
        _factionTable = factionTable;
        _factionProvincesTable = factionProvincesTable;
        Initialize();
    }

    private void Initialize()
    {
        DiplomacyVision();
        Vision();
    }

    private void DiplomacyVision()
    {
        var england = _factionTable.GetFaction("england");
        var france = _factionTable.GetFaction("france");
        var englandVision = new HashSet<FactionTemplate>() { england };
        var franceVision = new HashSet<FactionTemplate>() { france };
        _visionContact.Add(england, englandVision);
        _visionContact.Add(france, franceVision);
    }

    private void Vision()
    {
        var england = _factionTable.GetFaction("england");
        var france = _factionTable.GetFaction("france");
        var englandVision = new HashSet<ProvinceTemplate>(_factionProvincesTable.GetProvinces(england));
        var franceVision = new HashSet<ProvinceTemplate>(_factionProvincesTable.GetProvinces(france));
        _visibleProvinces.Add(england, englandVision);
        _visibleProvinces.Add(france, franceVision);
    }
}