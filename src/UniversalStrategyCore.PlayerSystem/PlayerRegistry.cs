using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.PlayerSystem;

public class PlayerRegistry : IPlayerRegistry
{
    private readonly Dictionary<PlayerId, Player> _idToPlayer = [];

    public Result<bool> RegisterPlayer(Player player)
    {
        if (_idToPlayer.TryAdd(player.Id, player)) return true;

        return Error.AlreadyExist(player.Id, nameof(_idToPlayer));
    }

    public Result<bool> DeletePlayer(PlayerId id)
    {
        if (_idToPlayer.Remove(id)) return true;

        return Error.NotFound(id, nameof(_idToPlayer));
    }

    public Result<Player> GetPlayer(PlayerId id)
    {
        return _idToPlayer.TryGetValue(id, out var player)
            ? player
            : Error.NotFound(id, nameof(_idToPlayer));
    }
}