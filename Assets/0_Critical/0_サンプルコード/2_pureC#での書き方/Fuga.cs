using UnityEngine;

public class Fuga
{
    private string message;

    private Hoge hoge;

    public Fuga(Hoge hoge)
    {
        message = hoge.message;
    }

    public void fuga()
    {
        Debug.Log(message);
    }
}
