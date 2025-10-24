using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Character>(Lifetime.Singleton);
        builder.Register<Movement>(Lifetime.Singleton);
        builder.Register<PlayerInput>(Lifetime.Singleton);
    }
}
