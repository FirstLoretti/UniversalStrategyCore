namespace UniversalStrategyCore.Shared;

public class NameGenerator(ICultureNamesRepository repository) : INameGenerator
{
    private readonly HashSet<string> _generatedNames = [];

    public Result<string> GenerateName(FactionId id)
    {
        var result = repository.GetCultureNames(id);
        if (!result.IsSuccess)
            return result.Error;

        var names = result.Value;
        string fullName;
        do
        {
            var firstName = names.FirstNames[Random.Shared.Next(names.FirstNames.Length)];
            var lastName = names.LastNames[Random.Shared.Next(names.LastNames.Length)];
            fullName = $"{firstName} {lastName}";
        } 
        while (!_generatedNames.Add(fullName));

        return fullName;
    }
}