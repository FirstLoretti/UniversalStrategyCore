using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Mediators.FactionProvince;

public class FactionVisionTable
{
    public IReadOnlyDictionary<Shared.Faction, HashSet<Shared.Faction>> VisionContact => _visionContact;
    public IReadOnlyDictionary<Shared.Faction, HashSet<Shared.Province>> VisibleProvinces => _visibleProvinces;

    private readonly Dictionary<Shared.Faction, HashSet<Shared.Faction>> _visionContact = [];
    private readonly Dictionary<Shared.Faction, HashSet<Shared.Province>> _visibleProvinces = [];
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
        var englandVision = new HashSet<Shared.Faction>() { england };
        var franceVision = new HashSet<Shared.Faction>() { france };
        _visionContact.Add(england, englandVision);
        _visionContact.Add(france, franceVision);
    }

    private void Vision()
    {
        var england = _factionTable.GetFaction("england");
        var france = _factionTable.GetFaction("france");
        var englandVision = new HashSet<Shared.Province>(_factionProvincesTable.GetProvinces(england));
        var franceVision = new HashSet<Shared.Province>(_factionProvincesTable.GetProvinces(france));
        _visibleProvinces.Add(england, englandVision);
        _visibleProvinces.Add(france, franceVision);
    }
}