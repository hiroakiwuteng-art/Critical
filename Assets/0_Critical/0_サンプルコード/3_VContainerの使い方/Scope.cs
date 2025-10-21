using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityEngine.UI;

public class Scope : LifetimeScope
{
    [SerializeField]
    private Hogera button;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<Fuga>(Lifetime.Singleton);
        builder.Register<Hoge>(Lifetime.Singleton);

        builder.RegisterEntryPoint<Piyo>();

        builder.RegisterComponent(button);
    }
}
