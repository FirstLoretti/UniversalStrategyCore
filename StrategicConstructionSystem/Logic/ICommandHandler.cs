namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public interface ICommandHandler<T>
{
    public Result<IUndoAction> Handle(T command);
}