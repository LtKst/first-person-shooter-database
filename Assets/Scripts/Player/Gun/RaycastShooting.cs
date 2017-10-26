using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShooting : MonoBehaviour
{
    private HitEffect hitEffect;
    private AudioSource audioSource;

    private bool canShoot = true;
    private bool reloading = false;

    [SerializeField]
    private int magCapacity = 30;
    private int bulletsInMag;

    [SerializeField]
    private Text magText;

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
    [SerializeField]
    private AudioClip reloadClip;

    [Header("Animation")]
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private ParticleSystem muzzleFlash;

    [SerializeField]
    private AimDownSights aimDownSights;

    private void Awake()
    {
        hitEffect = GetComponent<HitEffect>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        bulletsInMag = magCapacity;
        UpdateMagText();
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, transform.forward * range, Color.red);

        if (canShoot && !reloading && (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) && automatic))
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsInMag < magCapacity)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;

        if (bulletsInMag > 0)
        {
            muzzleFlash.Play();

            Vector3 forward = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, forward, out hit, range))
            {
                if (hit.collider.GetComponent<Explosive>())
                {
                    hit.collider.GetComponent<Explosive>().Explode();
                }

                if (hit.collider.transform.root != null && hit.collider.transform.root.GetComponent<Enemy>())
                {
                    hit.collider.transform.root.GetComponent<Enemy>().Die();
                }

                if (hit.collider.GetComponent<Rigidbody>())
                {
                    hit.collider.GetComponent<Rigidbody>().AddForce(forward * shotForce, ForceMode.Force);
                }

                if (hit.collider.sharedMaterial != null)
                {
                    hitEffect.PlayEffect(hit);
                }
            }

            audioSource.PlayOneShot(shootClips[Random.Range(0, shootClips.Length)], Random.Range(0.8f, 1));

            bulletsInMag--;
            UpdateMagText();
        }
        else
        {
            audioSource.PlayOneShot(emptyShootClip);
        }

        yield return new WaitForSeconds(fireRate);

        canShoot = true;
    }

    private IEnumerator Reload()
    {
        reloading = true;

        aimDownSights.canAimDownSights = false;
        animator.SetBool("reloading", true);
        audioSource.PlayOneShot(reloadClip);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        animator.SetBool("reloading", false);
        aimDownSights.canAimDownSights = true;

        bulletsInMag = magCapacity;
        UpdateMagText();

        reloading = false;
    }

    private void UpdateMagText()
    {
        magText.text = bulletsInMag + "/" + magCapacity;
    }
}
