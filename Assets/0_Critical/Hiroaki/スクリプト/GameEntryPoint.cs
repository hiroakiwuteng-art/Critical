using UnityEngine;
using VContainer.Unity;

public class GameEntryPoint : IStartable
{
    private GameSystem gameSystem;

    public GameEntryPoint(GameSystem gameSystem)
    {
        this.gameSystem = gameSystem;
    }
    public void Start()
    {
        gameSystem.Initialize();
    }
}
