using core;
using UnityEngine;

public class JumpState:IState<SlimeStateData>
{
    private float firstY;
    private float distance;

    private Animator _animator;
    private Transform _slimeTf;
    private Transform _playerTf;

    private float JumpStopCount;
    public JumpState(Animator animator, Transform slimeTf, Transform playerTf)
    {
        _animator = animator;
        _slimeTf = slimeTf;
        _playerTf = playerTf;
    }

    public void Enter()
    {
        if (_slimeTf.localPosition.z > _playerTf.localPosition.z)
        {
            _slimeTf.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _slimeTf.localRotation = Quaternion.Euler(0, 0, 0);
        }
        distance = _playerTf.localPosition.z - _slimeTf.localPosition.z;
        firstY =_slimeTf.localPosition.y;
        _animator.Play("Jump");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >0.3 && stateInfo.normalizedTime<0.6)
        {
            Vector3 a = _slimeTf.localPosition;
            a.y += 20 * Time.deltaTime;
            a.z += distance * Time.deltaTime;
            _slimeTf.localPosition = a;
        }

        if (stateInfo.normalizedTime > 0.7 && stateInfo.normalizedTime<1)
        {
            Vector3 a = _slimeTf.localPosition;
            a.y -= 20 * Time.deltaTime;
            _slimeTf.localPosition = a;
        }
        if(stateInfo.normalizedTime >= 1)
        {
            JumpStopCount += Time.deltaTime;
            if (JumpStopCount > 1.5)
            {
                return data.ReturnTrigger;
            }
        }
            
        return null;
    }
    public void Exit()
    {
        Vector3 a=_slimeTf.localPosition;
        a.y = firstY;
        _slimeTf.localPosition = a;
        JumpStopCount = 0;
    }
}