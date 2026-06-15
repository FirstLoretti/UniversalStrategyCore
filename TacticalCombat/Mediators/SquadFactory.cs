using UniversalStrategyCore.TacticalCombat.Squad;
using UniversalStrategyCore.TacticalCombat.Unit;

namespace UniversalStrategyCore.TacticalCombat.Mediators;

public class SquadFactory(ISquadsTable squadsTable, IUnitsTable unitsTable)
{
    public TacticalSquad CreateSquad(string squadTemplateId)
    {
        var squadTemplate = squadsTable.GetSquadTemplate(squadTemplateId);
        var unitTemplate = unitsTable.GetUnitTemplate(squadTemplate.UnitTemplateId);
        var squad = new TacticalSquad(unitTemplate, squadTemplate.UnitsCount);
        return squad;
    }
}