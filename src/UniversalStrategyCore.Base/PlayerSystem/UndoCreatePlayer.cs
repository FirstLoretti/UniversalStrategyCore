using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.PlayerSystem;

public record UndoCreatePlayer(IPlayerRegistry PlayerRegistry, Player Player) : IUndoAction
{
    public void Undo() => PlayerRegistry.DeletePlayer(Player.Id);
    public void Redo() => PlayerRegistry.RegisterPlayer(Player);
}