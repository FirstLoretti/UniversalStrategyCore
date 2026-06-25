namespace UniversalStrategyCore.Shared;

public class SquadRepository : ISquadRepository
{
    private readonly Dictionary<SquadId, Squad> _idToSquad = [];

    public SquadRepository()
    {
        CreateSquads();
    }

    public Result<Squad> GetSquad(SquadId id)
    {
        if (_idToSquad.TryGetValue(id, out var squad)) return squad;

        return Error.NotFound(id, nameof(_idToSquad));
    }

    private void CreateSquads()
    {
        _idToSquad.Add(
            "swordmen", new(Id: "swordmen", DisplayName: "Мечники", UnitId: "swordman", UnitsCount: 1)
        );
        _idToSquad.Add(
            "spearmen", new(Id: "spearmen", DisplayName: "Копейщики", UnitId: "spearman", UnitsCount: 100)
        );
    }
}