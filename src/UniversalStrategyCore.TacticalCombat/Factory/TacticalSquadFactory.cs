using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Entity;

namespace UniversalStrategyCore.TacticalCombat.Factory;

public class TacticalSquadFactory(
    ISquadRepository squadRepository,
    IUnitRepository unitRepository,
    IExperienceSquadTable experienceTable
)
{
    public Result<TacticalSquad> CreateSquad(SquadId id, int number, FactionId factionHolder)
    {
        var getSquadResult = squadRepository.GetSquad(id);
        if (!getSquadResult.IsSuccess) return getSquadResult.Error;

        var getUnitResult = unitRepository.GetUnit(getSquadResult.Value.UnitId);
        if (!getUnitResult.IsSuccess) return getUnitResult.Error;

        TacticalSquad squad = new(
            
            number: number,
            factionHolder: factionHolder,
            unit: getUnitResult.Value,
            unitsCount: getSquadResult.Value.UnitsCount,
            experienceSquadTable: experienceTable);

        return squad;
    }
}