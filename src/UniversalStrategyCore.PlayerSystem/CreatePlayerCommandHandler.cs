using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.PlayerSystem;

public class CreatePlayerCommandHandler(
    IPlayerRegistry playerRegistry
) : ICommandHandler<CreatePlayerCommand>
{
    public Result<IUndoAction> Handle(CreatePlayerCommand command)
    {
        Player player = new(command.Name, command.Name, command.IsAI);
        var result = playerRegistry.RegisterPlayer(player);
        if (result.IsSuccess)
            return new UndoCreatePlayer(playerRegistry, player);

        return result.Error;
    }
}