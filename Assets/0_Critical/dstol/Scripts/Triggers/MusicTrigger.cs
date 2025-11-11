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
        bgmManager.PlayTrack(trackNumber);
        alreadyEntered = true;
    }
}
