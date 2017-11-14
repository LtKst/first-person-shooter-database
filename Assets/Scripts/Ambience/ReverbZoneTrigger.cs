using UnityEngine;

public class ReverbZoneTrigger : MonoBehaviour
{
    private AudioReverbZone audioReverbZone;

    private void Awake()
    {
        audioReverbZone = GetComponent<AudioReverbZone>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioReverbZone.enabled = !audioReverbZone.enabled;
    }
}
