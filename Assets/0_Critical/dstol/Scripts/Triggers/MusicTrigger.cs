using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private BGMManager bgmManager;
    [SerializeField] private int trackNumber;
    [SerializeField] private bool alreadyEntered;

    private void Start()
    {
        if (TryGetComponent<Renderer>(out Renderer thisRenderer))
        {
            thisRenderer.enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.TryGetComponent<Character>(out Character character);
        if(character.IsPlayer && !alreadyEntered)
        {
            bgmManager.PlayTrack(trackNumber);
            alreadyEntered = true;
        }
    }
}
