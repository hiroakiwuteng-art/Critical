
namespace core
{
    public interface IStateData
    {
        (StateId, IState)[] GetStates();
        /// <summary>
        /// from,trigger,to
        /// </summary>
        /// <returns></returns>
        (StateId, TriggerId, StateId)[] GetTransitions();
    }
}
