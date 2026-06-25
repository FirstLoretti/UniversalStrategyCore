using NSubstitute;
using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Test.Shared;

public class CultureNamePoolTest
{
    [Fact]
    public void GenerateNames_ShouldGenerate4UniqueFullNames_When4ArePossible()
    {
        var repositoryMock = Substitute.For<ICultureNamesRepository>();
        CultureNames names = new(["A", "B"], ["C", "D"]);
        FactionId[] factionIds = ["1",];
        repositoryMock.GetCultureNames(factionIds[0]).Returns(names);

        CultureNamesPool pool = new(repositoryMock, factionIds);
        var result = pool.GetNames(factionIds[0]);

        Assert.True(result.IsSuccess);
        var generatedNames = result.Value;
        Assert.Contains("A C", generatedNames);
        Assert.Contains("A D", generatedNames);
        Assert.Contains("B C", generatedNames);
        Assert.Contains("B D", generatedNames);
    }
}