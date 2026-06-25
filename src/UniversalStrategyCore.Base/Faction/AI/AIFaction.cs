using UniversalStrategyCore.Shared;

namespace UniversalStrategyCore.Factionn.AI;

public class AIFaction(Shared.Faction faction, DefaultState defaultState, AggressiveState aggressiveState)
{
    public Shared.Faction Faction { get; } = faction;
    public DefaultState DefaultState { get; } = defaultState;
    public AggressiveState AggressiveState { get; } = aggressiveState;

    private IState _state = defaultState;

    public void OnTurnEnd()
    {
        UpdateState();
        _state.Strategy.Apply(this);
    }

    public void ChangeState(IState state) => _state = state;

    private void UpdateState() => _state.Update(this);
}