using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private void Start()
    {
        if(TryGetComponent<Renderer>(out Renderer thisRenderer))
        {
            thisRenderer.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        bool isCharacter = other.TryGetComponent<Character>(out Character character);
        if(isCharacter)
        {
            character.Die();
        }
    }
}
