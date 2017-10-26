using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [Header("Flesh")]
    [SerializeField]
    private AudioClip[] fleshImpactClips;
    [SerializeField]
    public GameObject fleshHitEffect;

    [Header("Metal")]
    [SerializeField]
    private AudioClip[] metalImpactClips;
    [SerializeField]
    public GameObject metalHitEffect;

    [Header("Wood")]
    [SerializeField]
    private AudioClip[] woodImpactClips;
    [SerializeField]
    public GameObject woodHitEffect;

    [Header("Stone")]
    [SerializeField]
    private AudioClip[] stoneImpactClips;
    [SerializeField]
    public GameObject stoneHitEffect;

    [Header("Sand")]
    [SerializeField]
    private AudioClip[] sandImpactClips;
    [SerializeField]
    public GameObject sandHitEffect;

    [Header("Bell")]
    [SerializeField]
    private AudioClip[] bellImpactClips;

    public void PlayEffect(RaycastHit hit)
    {
        switch (hit.collider.sharedMaterial.name)
        {
            case "Flesh":
                SpawnImpactSound(hit, fleshImpactClips[Random.Range(0, fleshImpactClips.Length)]);
                SpawnDecal(hit, fleshHitEffect);

                break;

            case "Metal":
                SpawnImpactSound(hit, metalImpactClips[Random.Range(0, metalImpactClips.Length)]);
                SpawnDecal(hit, metalHitEffect);

                break;

            case "Wood":
                SpawnImpactSound(hit, woodImpactClips[Random.Range(0, woodImpactClips.Length)]);
                SpawnDecal(hit, woodHitEffect);

                break;

            case "Stone":
                SpawnImpactSound(hit, stoneImpactClips[Random.Range(0, stoneImpactClips.Length)]);
                SpawnDecal(hit, stoneHitEffect);

                break;

            case "Sand":
                SpawnImpactSound(hit, sandImpactClips[Random.Range(0, sandImpactClips.Length)]);
                SpawnDecal(hit, sandHitEffect);

                break;
            case "Bell":
                SpawnImpactSound(hit, bellImpactClips[Random.Range(0, bellImpactClips.Length)]);
                SpawnDecal(hit, metalHitEffect);

                break;
        }
    }

    private void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnedDecal = Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
        spawnedDecal.transform.SetParent(hit.collider.transform);
    }

    private void SpawnImpactSound(RaycastHit hit, AudioClip clip)
    {
        GameObject impactSound = new GameObject(clip.name);
        impactSound.transform.position = hit.point;

        impactSound.AddComponent<AudioSource>().spatialBlend = 1;
        impactSound.GetComponent<AudioSource>().PlayOneShot(clip);

        Destroy(impactSound, clip.length);
    }
}
