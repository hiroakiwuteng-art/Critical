using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] bgms;
    
    public void ChangeTrack(int track)
    {
        if (bgms[track] == audioSource.clip)
        {
            return;
        }
        ChangeTrack(bgms[track]);
    }
    public void ChangeTrack(AudioClip clip)
    {
        if(audioSource.clip == clip)
        {
            return;
        }
        audioSource.clip = clip;
    }
    public void PlayTrack(int track)
    {
        Debug.Log("Player Track #" + track);
        ChangeTrack(track);
        audioSource.Play();
    }
    public void PlayTrack(AudioClip track)
    {
        ChangeTrack(track);
        audioSource.Play();
    }
}
