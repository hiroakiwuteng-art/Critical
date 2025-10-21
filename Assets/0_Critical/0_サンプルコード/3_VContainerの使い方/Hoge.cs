using UnityEngine;

public class Hoge
{
    private string message;

    public Hoge(Fuga fuga)
    {
        message = fuga.fuga;
    }

    public void hoge()
    {
        Debug.Log(message);
    }
}
