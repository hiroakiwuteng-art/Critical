using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameSystem>(Lifetime.Singleton);

        builder.RegisterEntryPoint<GameEntryPoint>();
    }
}
