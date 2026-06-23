using UniversalStrategyCore.PlayerRegistrar;
using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Test;

public class PlayerManagerTests
{
    [Fact]
    public void CreatePlayer_ReturnSuccess_WhenNameIsUnique()
    {
        var playerManager = new PlayerManager();
        var result = playerManager.CreatePlayer("Loretty", false);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
    }

    [Fact]
    public void CreatePlayer_ReturnFailure_WhenNameIsDuplicate()
    {
        var playerManager = new PlayerManager();
        var result = playerManager.CreatePlayer("Loretty", false);
        var result2 = playerManager.CreatePlayer("Loretty", false);
        Assert.False(result2.IsSuccess);
        Assert.Null(result2.Value);
        Assert.Equal(Error.PlayerAlredyExist(), result2.Error);
    }
}