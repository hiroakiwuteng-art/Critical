using core;
using UnityEngine;

public class IdleState:IState<SlimeStateData>
{
    private Animator _animator;
    private float stopTime;

    public IdleState(Animator animator)
    {
        _animator = animator;
    }
    public void Enter()
    {
        _animator.Play("Idle");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        stopTime += Time.deltaTime;
        if (stopTime > 1)
        {
            return data.RushTrigger;
        }
        return null;
    }
    public void Exit()
    {
        stopTime = 0;
    }
}
