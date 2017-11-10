using System.Collections;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    private WeaponAmmo weaponAmmo;
    private WeaponAudio weaponAudio;
    private WeaponDatabase weaponDatabase;
    private ImpactEffect impactEffect;
    private Light lightFlash;

    [SerializeField]
    private Transform cameraTransform;

    private bool canShoot = true;

    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private float shotForce = 200f;
    [SerializeField]
    private bool automatic = false;
    [SerializeField]
    private float fireRate = 0.5f;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip[] shootClips;
    [SerializeField]
    private AudioClip emptyShootClip;

    [Header("Effects")]
    [SerializeField]
    private ParticleSystem[] shootParticleSystems;

    private void Awake()
    {
        weaponAmmo = GetComponent<WeaponAmmo>();
        weaponAudio = GetComponent<WeaponAudio>();
        weaponDatabase = GetComponent<WeaponDatabase>();

        impactEffect = GetComponent<ImpactEffect>();
        lightFlash = GetComponent<Light>();
    }

    private void Update()
    {
        Debug.DrawLine(cameraTransform.position, cameraTransform.forward * range, Color.red);

        if (canShoot && !weaponAmmo.Reloading && (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1") && automatic))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (weaponAmmo.BulletsInMag > 0)
        {
            StartCoroutine(LightFlash());

            for (int i = 0; i < shootParticleSystems.Length; i++)
            {
                shootParticleSystems[i].Play();
            }

            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(cameraTransform.position, forward, out hit, range))
            {
                if (hit.collider.GetComponent<Explosive>())
                {
                    hit.collider.GetComponent<Explosive>().Explode();
                }

                if (hit.collider.transform.root != null && hit.collider.transform.root.GetComponent<EnemyDeath>())
                {
                    hit.collider.transform.root.GetComponent<EnemyDeath>().Die();
                }

                if (hit.collider.GetComponent<Rigidbody>())
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(forward * shotForce, ForceMode.Force);
                }

                if (hit.collider.sharedMaterial != null)
                {
                    impactEffect.PlayEffect(hit);
                }
            }

            weaponAudio.PlayClip(shootClips[Random.Range(0, shootClips.Length)], Random.Range(0.8f, 1));

            weaponAmmo.BulletsInMag--;
            
            StartCoroutine(weaponDatabase.QueryShot(transform.position, hit.point, hit.transform != null ? hit.transform.name : "Nothing"));
        }
        else
        {
            weaponAudio.PlayClip(emptyShootClip);
        }

        yield return new WaitForSeconds(fireRate);

        canShoot = true;
    }

    private IEnumerator LightFlash()
    {
        lightFlash.enabled = true;
        yield return new WaitForSeconds(.1f);
        lightFlash.enabled = false;
    }
}
