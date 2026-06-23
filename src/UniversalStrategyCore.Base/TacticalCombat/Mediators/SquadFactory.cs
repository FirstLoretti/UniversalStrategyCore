using UniversalStrategyCore.TacticalCombat.Squad;
using UniversalStrategyCore.TacticalCombat.Unit;

namespace UniversalStrategyCore.TacticalCombat.Mediators;

public class SquadFactory(ISquadsTable squadsTable, IUnitsTable unitsTable)
{
    private int _squadId;
    public TacticalSquad CreateSquad(string squadTemplateId)
    {
        var squadTemplate = squadsTable.GetSquadTemplate(squadTemplateId);
        var unitTemplate = unitsTable.GetUnitTemplate(squadTemplate.UnitTemplateId);
        var squad = new TacticalSquad(++_squadId, unitTemplate, squadTemplate.UnitsCount);
        return squad;
    }
}