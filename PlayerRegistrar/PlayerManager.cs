using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.PlayerRegistrar;

public class PlayerManager
{
    private readonly Dictionary<string, Player> _players = [];

    public Result<Player> CreatePlayer(string name, bool isAI)
    {
        if (_players.ContainsKey(name))
        {
            return Error.PlayerAlredyExist();
        }
        var player = new Player(name, isAI);
        _players.Add(player.Name, player);
        return player;
    }
}