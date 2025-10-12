using UnityEngine;

public class Piyo
{
    Hoge hoge1;
    Hoge hoge2;

    Fuga fuga1;
    Fuga fuga2;

    public Piyo()
    {
        hoge1 = new Hoge("Hello");
        fuga1 = new Fuga(hoge1);

        hoge2 = new Hoge("Good Morning");
        fuga2 = new Fuga(hoge2);
    }

    public void Init()
    {
        fuga1.fuga();
        fuga2.fuga();
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fuga1.fuga();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            fuga2.fuga();
        }
    }
}
