using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public interface ICommandHandler<T>
{
    public Result<IUndoAction> Handle(T command);
}