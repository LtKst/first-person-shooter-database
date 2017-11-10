using UnityEngine;

public class EnableUnderwater : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour[] components;

    [SerializeField]
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        for (int i = 0; i < components.Length; i++)
        {
            bool enabled = Underwater.playerUnderwater;

            components[i].enabled = enabled;

            if (audioSource != null)
            {
                //audioSource.enabled = enabled;

                audioSource.volume = Mathf.Lerp(audioSource.volume, enabled ? 0.5f : 0, Time.deltaTime);
            }
        }
    }
}
