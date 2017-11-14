using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmo : MonoBehaviour
{
    private WeaponAudio weaponAudio;
    private WeaponAnimation weaponAnimation;

    [SerializeField]
    private AudioClip reloadClip;
    [SerializeField]
    private AnimationClip reloadAnimation;

    private bool reloading = false;
    public bool Reloading
    {
        get
        {
            return reloading;
        }
    }

    [SerializeField]
    private int totalAmmo = 330;
    public int TotalAmmo
    {
        get
        {
            return totalAmmo;
        }
        set
        {
            totalAmmo = value;
            totalAmmo = Mathf.Clamp(totalAmmo, 0, 3000);
            UpdateAmmoUI();
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
            UpdateAmmoUI();
        }
    }

    [Header("UI")]
    [SerializeField]
    private Text ammoText;

    [SerializeField]
    private AimDownSights aimDownSights;

    private void Awake()
    {
        weaponAudio = GetComponent<WeaponAudio>();
        weaponAnimation = GetComponent<WeaponAnimation>();

        BulletsInMag = magCapacity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && bulletsInMag < magCapacity && TotalAmmo > 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        reloading = true;

        aimDownSights.canAimDownSights = false;
        weaponAnimation.reloading = true;
        weaponAudio.PlayClip(reloadClip);

        yield return new WaitForSeconds(reloadAnimation.length);

        weaponAnimation.reloading = false;
        aimDownSights.canAimDownSights = true;

        int bulletsLost = BulletsInMag;

        if (TotalAmmo + BulletsInMag >= 30)
        {
            BulletsInMag = magCapacity;
        }
        else
        {
            BulletsInMag += TotalAmmo - BulletsInMag;
        }

        TotalAmmo -= 30 - bulletsLost;

        reloading = false;
    }

    private void UpdateAmmoUI()
    {
        ammoText.text = BulletsInMag + "/" + TotalAmmo;
    }
}
