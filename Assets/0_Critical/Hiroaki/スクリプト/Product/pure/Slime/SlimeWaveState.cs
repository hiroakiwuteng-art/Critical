using core;

public class SlimeWaveState:IState
{
    StateMachine _slimeSM;
    SlimeStateData _slimeSD;
    public SlimeWaveState(StateMachine slimeSM, SlimeStateData slimeSD) 
    {
        _slimeSM = slimeSM;
        _slimeSD = slimeSD;
    }

    public void Enter() 
    {
        _slimeSM.SetInitialize(_slimeSD.Idle);
    }
    public void Tick()
    {
        _slimeSM.Tick();
    }
    public void Exit()
    {
        _slimeSM.Exit();
    }
}