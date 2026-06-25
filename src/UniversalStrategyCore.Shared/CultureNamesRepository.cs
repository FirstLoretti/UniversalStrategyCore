namespace UniversalStrategyCore.Shared;

public class CultureNamesRepository : ICultureNamesRepository
{
    private readonly Dictionary<FactionId, CultureNames> _factionIdToNames = [];

    public CultureNamesRepository()
    {
        InitializeNames();
    }

    public Result<CultureNames> GetCultureNames(FactionId id)
    {
        if (!_factionIdToNames.TryGetValue(id, out var names))
            return Error.NotFound(id, nameof(_factionIdToNames));

        return names;
    }

    private void InitializeNames()
    {
        _factionIdToNames.Add("england", new CultureNames(
            ["William", "Richard", "Henry"],
            ["the Brave", "the Lionheart"]
        ));
        _factionIdToNames.Add("france", new CultureNames(
            ["Philip, Henry"],
            ["the Wise", "the Fair"]
        ));
    }
}