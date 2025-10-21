using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class Hogera : IStartable
{
    private Button button;
    private Hoge hoge;
    public Hogera(Button button , Hoge hoge)
    {
        this.button = button;
        this.hoge = hoge;
    }

    public void Start()
    {
        button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        hoge.hoge();
    }
}
