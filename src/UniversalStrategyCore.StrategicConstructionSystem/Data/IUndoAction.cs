namespace UniversalStrategyCore.StrategicConstructionSystem.Data;

public interface IUndoAction
{
    public void Undo();
    public void Redo();
}