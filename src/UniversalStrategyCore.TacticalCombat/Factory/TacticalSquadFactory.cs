using UniversalStrategyCore.Shared;
using UniversalStrategyCore.TacticalCombat.Entity;

namespace UniversalStrategyCore.TacticalCombat.Factory;

public class TacticalSquadFactory(
    ISquadRepository squadRepository, IUnitRepository unitRepository, IExperienceSquadTable experienceTable
)
{
    private int _squadId;
    
    public Result<TacticalSquad> CreateSquad(SquadId id)
    {
        var getSquadResult = squadRepository.GetSquad(id);
        if(!getSquadResult.IsSuccess) return getSquadResult.Error;

        var getUnitResult = unitRepository.GetUnit(getSquadResult.Value.UnitId);
        if(!getUnitResult.IsSuccess) return getUnitResult.Error;

        TacticalSquad squad = new (++_squadId, getUnitResult.Value, getSquadResult.Value.UnitsCount, experienceTable);
        return squad;
    }
}