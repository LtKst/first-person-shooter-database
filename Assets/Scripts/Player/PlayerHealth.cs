using UnityEngine;
using UnityEngine.UI;

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

            UpdateHealthUI();
        }
    }

    [Header("UI")]
    [SerializeField]
    private Image healthImage;

    private void Awake()
    {
        Health = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Health -= 5;
        }
    }

    private void UpdateHealthUI()
    {
        healthImage.rectTransform.offsetMax = new Vector2(0f - (200f / maxHealth) * (maxHealth - health), healthImage.rectTransform.offsetMax.y);
    }
}
