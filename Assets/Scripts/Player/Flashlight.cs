using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light flashlight;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flashlightClip;

    private void Awake()
    {
        flashlight = GetComponent<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            audioSource.PlayOneShot(flashlightClip);
        }
    }
}
