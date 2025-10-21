using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class Hogera : MonoBehaviour
{
    [SerializeField]private Button button;
    [Inject]private Hoge hoge;


    private void Start()
    {
        button.onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        hoge.hoge();
    }
}
