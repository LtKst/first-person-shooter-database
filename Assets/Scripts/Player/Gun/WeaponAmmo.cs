  using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmo : MonoBehaviour
{
    private WeaponAudio weaponAudio;
    private WeaponAnimation weaponAnimation;

    [SerializeField]
    private AudioClip reloadClip;

    private bool reloading = false;
    public bool Reloading
    {
        get
        {
            return reloading;
        }
    }

    [SerializeField]
    private int magCapacity = 30;

    private int bulletsInMag;
    public int BulletsInMag
    {
        get
        {
            return bulletsInMag;
        }
        set
        {
            bulletsInMag = value;
            UpdateMagUI();
        }
    }

    [SerializeField]
    private Text magText;

    [SerializeField]
    private AimDownSights aimDownSights;

    private void Awake()
    {
        weaponAudio = GetComponent<WeaponAudio>();
        weaponAnimation = GetComponent<WeaponAnimation>();
    }

    private void Start()
    {
        BulletsInMag = magCapacity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && bulletsInMag < magCapacity)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        reloading = true;

        aimDownSights.canAimDownSights = false;
        weaponAnimation.SetReloadingAnimation(true);
        weaponAudio.PlayClip(reloadClip);

        yield return new WaitForSeconds(weaponAnimation.CurrentAnimationLength);

        weaponAnimation.SetReloadingAnimation(false);
        aimDownSights.canAimDownSights = true;

        BulletsInMag = magCapacity;

        reloading = false;
    }

    private void UpdateMagUI()
    {
        magText.text = bulletsInMag + "/" + magCapacity;
    }
}
