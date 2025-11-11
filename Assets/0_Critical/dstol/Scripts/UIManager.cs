using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleUIElement(int index)
    {
        if (uiElements[index].activeInHierarchy)
        {
            uiElements[index].SetActive(false);
        }
        else
        {
            uiElements[index].SetActive(true);
        }
    }
    public GameObject[] UIElements
    {
        get { return uiElements; }
    }
}
