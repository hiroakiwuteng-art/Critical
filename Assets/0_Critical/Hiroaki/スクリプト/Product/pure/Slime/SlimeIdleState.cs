using core;
using UnityEngine;

public class SlimeIdleState:IState
{
    Animator _animator;
    AnimatorStateInfo _stateInfo;
    public SlimeIdleState()
    {

    }
    public void Enter()
    {
        _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
    }
    public void Tick()
    {
        if (_stateInfo.normalizedTime >= 0)
        {
            
        }
    }
    public void Exit()
    {
        Debug.Log("slime idle exit");
    }
}
