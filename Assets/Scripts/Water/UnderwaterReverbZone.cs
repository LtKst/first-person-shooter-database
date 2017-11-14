using UnityEngine;

public class UnderwaterReverbZone : MonoBehaviour
{
    private AudioReverbZone audioReverbZone;

    private void Awake()
    {
        audioReverbZone = GetComponent<AudioReverbZone>();
    }

    private void Update()
    {
        audioReverbZone.enabled = Underwater.playerUnderwater;
    }
}
