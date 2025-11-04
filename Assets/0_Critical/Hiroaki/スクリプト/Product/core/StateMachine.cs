using System.Collections.Generic;
namespace core
{
    public class StateMachine
    {
        public IStateData StateData { get; private set; }

        private readonly Dictionary<StateId, IState> _states = new();
        private readonly Dictionary<(StateId, TriggerId), StateId> _transitions = new();
        private StateId _currentStateId;
        private IState _currentState;
        public StateMachine(IStateData stateData)
        {
            StateData = stateData;
            addStates(StateData.GetStates());
            addTransitions(StateData.GetTransitions());
        }

        public void SetInitialize(StateId id)
        {
            _currentStateId = id;
            _currentState = _states[_currentStateId];
            _currentState.Enter();
        }
        public void Tick()
        {
            _currentState.Tick();
        }
        public void Exit()
        {
            _currentState.Exit();
        }
        public void ChangeState(TriggerId id)
        {
            var key = (_currentStateId, id);
            if(!_transitions.TryGetValue(key,out var next))
            {
                return;
            }
            _currentState.Exit();
            _currentStateId = next;
            _currentState = _states[_currentStateId];
            _currentState.Enter();
        }

        private void addStates(params (StateId id , IState state)[] states)
        {
            foreach (var i in states)
            {
                _states[i.id] = i.state;
            }
        }
        private void addTransitions(params(StateId from,TriggerId trigger,StateId to)[] transitions)
        {
            foreach(var i in transitions)
            {
                _transitions[(i.from, i.trigger)] = i.to;
            }
        }
    }
}
