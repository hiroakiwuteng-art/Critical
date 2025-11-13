using UnityEngine;
using core;
public class ReturnState:IState<SlimeStateData>
{
    private Animator _animator;

    private Vector3 fixedPosition_1 = new (0,-7,-10);
    private Vector3 fixedPosition2 = new(0,-7,10);
    private Vector3 targetPosition;
    private float distance;

    private float firstY;

    private Transform _slimeTf;

    public ReturnState(Animator animator,Transform slimeTf)
    {
        _animator = animator;
        _slimeTf = slimeTf;
    }

    public void Enter()
    {
        if (_slimeTf.localPosition.z < 0)
        {
            targetPosition = fixedPosition_1;
        }
        else
        {
            targetPosition = fixedPosition2;
        }
        distance=targetPosition.z-_slimeTf.localPosition.z;
        firstY = _slimeTf.localPosition.y;
        _animator.Play("ReturnJump");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        Vector3 a = _slimeTf.localPosition;
        a.z += distance*8/10 * Time.deltaTime;
        if (stateInfo.normalizedTime <0.45)
        {
            a.y += 3 * Time.deltaTime;
            _slimeTf.localPosition = a;
        }
        else
        {
            a.y -= 3 * Time.deltaTime;
            _slimeTf.localPosition = a;
        }


        if (stateInfo.normalizedTime >= 0.9)
        {
            return data.IdleTrigger;
        }
        return null;
    }
    public void Exit()
    {
        Vector3 a = _slimeTf.localPosition;
        a.y = firstY;
        _slimeTf.localPosition = a;
    }
}
