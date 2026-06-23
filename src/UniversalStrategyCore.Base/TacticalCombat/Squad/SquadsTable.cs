using System.Diagnostics;

namespace UniversalStrategyCore.TacticalCombat.Squad;

public class SquadsTable : ISquadsTable
{
    private readonly Dictionary<string, SquadTemplate> _idToSquad = [];

    public SquadsTable()
    {
        Initialize();
    }

    public SquadTemplate GetSquadTemplate(string id)
    {
        if (_idToSquad.TryGetValue(id, out var squadTemplate))
        {
            return squadTemplate;
        }
        Debug.Assert(false, $"Отряда с id: {id} нет в словаре");
        return SquadTemplate.Missing;
    }

    private void Initialize()
    {
        AddSquad(new SquadTemplate(Id: "swordmen_1", UnitTemplateId: "swordman_1", UnitsCount: 1));
        AddSquad(new SquadTemplate(Id: "spearmen_1", UnitTemplateId: "spearman_1", UnitsCount: 100));
    }

    private void AddSquad(SquadTemplate squadTemplate)
    {
        var id = squadTemplate.Id.ToLowerInvariant();
        if (!_idToSquad.TryAdd(id, squadTemplate))
        {
            Debug.Assert(false, $"Отряд с id: {id} уже есть в таблице");
        }
    }
}