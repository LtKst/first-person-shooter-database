using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayClip(AudioClip clip, float volumeScale)
    {
        audioSource.PlayOneShot(clip, volumeScale);
    }
}
