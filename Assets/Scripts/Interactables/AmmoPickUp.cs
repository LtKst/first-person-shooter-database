using UnityEngine;

public class AmmoPickUp : Interactable
{
    private WeaponAmmo weaponAmmo;

    [SerializeField]
    private int bulletAmount = 15;

    private void Start()
    {
        weaponAmmo = GameObject.FindWithTag("Player").GetComponent<WeaponAmmo>();
    }

    protected override void Interact()
    {
        base.Interact();

        weaponAmmo.TotalAmmo += bulletAmount;

        Destroy(gameObject);
    }
}
