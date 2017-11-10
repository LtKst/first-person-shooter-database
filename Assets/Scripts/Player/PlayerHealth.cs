using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            health = Mathf.Clamp(health, 0, maxHealth);
        }
    }

    private void Awake()
    {
        health = maxHealth;
    }
}
