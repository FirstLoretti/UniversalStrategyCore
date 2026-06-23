namespace UniversalStrategyCore.StrategicConstructionSystem.Logic;

public interface IUndoAction
{
    public void Undo();
    public void Redo();
}