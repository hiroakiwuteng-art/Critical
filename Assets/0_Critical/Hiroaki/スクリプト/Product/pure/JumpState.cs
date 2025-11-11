using core;
using UnityEngine;

public class JumpState:IState<SlimeStateData>
{
    private Animator _animator;
    public JumpState(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        Debug.Log("enter jump");
        _animator.Play("Jump");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        return null;
    }
    public void Exit()
    {

    }
}