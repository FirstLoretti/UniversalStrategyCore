namespace UniversalStrategyCore.Shared;

public interface ISquadRepository
{
    public Result<Squad> GetSquad(SquadId id);
}