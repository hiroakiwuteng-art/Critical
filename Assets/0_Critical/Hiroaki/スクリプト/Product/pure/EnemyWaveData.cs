using core;

public class EnemyWaveData:IStateData
{
    public readonly StateId SlimeWave = new StateId("SlimeWave");
    public readonly StateId CloudWave= new StateId("CloudWave");

    public readonly SlimeWaveState SlimeWS;
    public readonly CloudWaveState CloudWS;

    public readonly TriggerId SlimeTrigger = new TriggerId("SlimeTrigger");
    public readonly TriggerId CloudTrigger = new TriggerId("CloudTrigger");

    public EnemyWaveData(SlimeWaveState slimeWS, CloudWaveState cloudWS)
    {
        SlimeWS = slimeWS;
        CloudWS = cloudWS;
    }
    public (StateId, IState)[] GetStates()
    {
        return new (StateId, IState)[]
        {
            (SlimeWave,SlimeWS),
            (CloudWave,CloudWS),
        };
    }
    public (StateId, TriggerId,StateId)[] GetTransitions()
    {
        return new (StateId, TriggerId, StateId)[]
        {
            (SlimeWave,CloudTrigger,CloudWave),
            (CloudWave,SlimeTrigger,SlimeWave)
        };
    }
}
