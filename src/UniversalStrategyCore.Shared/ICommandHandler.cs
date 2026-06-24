namespace UniversalStrategyCore.Shared;

public interface ICommandHandler<T> where T : IGameCommand
{
    public Result<IUndoAction> Handle(T command);
}