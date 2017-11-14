using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip defaultClip;
    [SerializeField]
    private AudioClip underwaterClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!Underwater.playerUnderwater && audioSource.clip != defaultClip)
        {
            audioSource.clip = defaultClip;
            audioSource.Play();
        }
        else if (Underwater.playerUnderwater && audioSource.clip != underwaterClip)
        {
            audioSource.clip = underwaterClip;
            audioSource.Play();
        }
    }
}
