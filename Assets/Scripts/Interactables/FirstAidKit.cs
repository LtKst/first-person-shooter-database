using UnityEngine;

public class FirstAidKit : Interactable
{
    private PlayerHealth playerHealth;

    [SerializeField]
    private float healAmount = 25;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    protected override void Interact()
    {
        base.Interact();

        playerHealth.Health += healAmount;

        Destroy(gameObject);
    }
}
