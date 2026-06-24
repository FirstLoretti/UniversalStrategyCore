using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.PlayerSystem;

public interface IPlayerRegistry
{
    public Result<bool> RegisterPlayer(Player player);
    public Result<bool> DeletePlayer(PlayerId id);
    public Result<Player> GetPlayer(PlayerId id);
}