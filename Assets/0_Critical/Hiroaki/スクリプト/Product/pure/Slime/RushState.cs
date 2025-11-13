using core;
using UnityEngine;

public class RushState:IState<SlimeStateData>
{
    private Animator _animator;
    private Transform _slimeTf;
    private Transform _playerTf;

    private float PreStopCount;
    private float ReturnStopCount;

    private int speed=40;
    public RushState(Animator animator, Transform transform, Transform playerTf)
    {
        _animator = animator;
        _slimeTf = transform;
        _playerTf = playerTf;
    }

    public void Enter()
    {
        if(_slimeTf.localPosition.z>_playerTf.localPosition.z)
        {
            _slimeTf.localRotation = Quaternion.Euler(0, 180, 0);
            speed = -40;
        }
        else
        {
            _slimeTf.localRotation = Quaternion.Euler(0, 0, 0);
            speed = 40;
        }
            _animator.Play("PreRush");
    }
    public TriggerId? Tick(SlimeStateData data)
    {
        var _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (_stateInfo.IsName("PreRush"))
        {
            if (_stateInfo.normalizedTime >= 1)
            {
                PreStopCount+=Time.deltaTime;
                if (PreStopCount > 1)
                {
                    _animator.Play("AttackRush");
                }
            }
        }
        if (_stateInfo.IsName("AttackRush"))
        {
            Vector3 a = _slimeTf.localPosition;
            a.z+=speed*Time.deltaTime;
            _slimeTf.localPosition = a;

            if (_stateInfo.normalizedTime >= 1)
            {
                _animator.Play("ReturnRush");
            }
        }
        if (_stateInfo.IsName("ReturnRush"))
        {
            if (_stateInfo.normalizedTime >= 1)
            {
                ReturnStopCount += Time.deltaTime;
                if (ReturnStopCount > 1)
                {
                    return data.JumpTrigger;
                }
            }
        }

        return null;
    }
    public void Exit()
    {
        PreStopCount = 0;
        ReturnStopCount = 0;
    }
}