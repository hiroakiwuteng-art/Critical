using UnityEngine;

public class Hogera : MonoBehaviour
{
    private Piyo piyo;

    void Start()
    {
        piyo = new Piyo();
        piyo.Init();
    }
    void Update()
    {
        piyo.Tick();
    }
}
