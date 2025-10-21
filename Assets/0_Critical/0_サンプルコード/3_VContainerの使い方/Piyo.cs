using UnityEngine;
using VContainer.Unity;

public class Piyo : IStartable , ITickable
{
    private Hoge hoge;
    public Piyo(Hoge hoge)
    {
        this.hoge = hoge;
    }
    public void Start()
    {
        hoge.hoge();
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hoge.hoge();
        }
    }
}
