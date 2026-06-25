namespace UniversalStrategyCore.Shared;

public class CultureNamesPool
{
    private readonly ICultureNamesRepository _repository;
    private readonly Dictionary<FactionId, Queue<string>> _factionIdToNames = [];

    public CultureNamesPool(ICultureNamesRepository repository, IEnumerable<FactionId> activeFactions)
    {
        _repository = repository;
        GenerateNames(activeFactions);
    }

    public Result<Queue<string>> GetNames(FactionId factionId)
    {
        if(_factionIdToNames.TryGetValue(factionId, out var names))
            return names;
        
        return Error.NotFound(factionId, nameof(_factionIdToNames));
    }

    private Result<bool> GenerateNames(IEnumerable<FactionId> activeFactions)
    {
        List<Error> errors = [];

        foreach (var faction in activeFactions)
        {
            var result = _repository.GetCultureNames(faction);
            if (!result.IsSuccess)
            {
                errors.Add(result.Error);
                continue;
            }

            HashSet<string> names = [];
            foreach (var firstName in result.Value.FirstNames)
            {
                foreach (var lastName in result.Value.LastNames)
                {
                    var fullName = $"{firstName} {lastName}";
                    names.Add(fullName);
                }
            }
            string[] temp = [.. names];
            Random.Shared.Shuffle(temp);

            if (!_factionIdToNames.TryAdd(faction, new Queue<string>(temp)))
                errors.Add(Error.AlreadyExist(faction, nameof(_factionIdToNames)));
        }

        if (errors.Count > 0) return errors[0];

        return true;
    }
}