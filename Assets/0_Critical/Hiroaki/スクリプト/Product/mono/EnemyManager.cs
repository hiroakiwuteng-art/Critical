using UnityEngine;
using core;

public class EnemyManager : MonoBehaviour
{
    CloudWaveState _cloudWS;

    StateMachine _enemyWaveSM;

    EnemyWaveData _enemyWD;

    
    void Start()
    {
        _cloudWS = new CloudWaveState();
        _enemyWD = new EnemyWaveData(createSlimeWave(),_cloudWS);
        _enemyWaveSM=new StateMachine(_enemyWD);
        _enemyWaveSM.SetInitialize(_enemyWD.SlimeWave);
    }
    void Update()
    {
        _enemyWaveSM.Tick();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemyWaveSM.ChangeState(_enemyWD.CloudTrigger);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _enemyWaveSM.ChangeState(_enemyWD.SlimeTrigger);
        }
    }

    SlimeWaveState createSlimeWave()
    {
        SlimeStateData slimeSD = new SlimeStateData(
            new SlimeIdleState(),
            new SlimeJumpState(),
            new SlimeRushState(),
            new SlimeReturnPositionState());

        StateMachine stateMachine = new StateMachine(slimeSD);

        return new SlimeWaveState(stateMachine, slimeSD);
    }
}
