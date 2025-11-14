using UnityEngine;
using UnityEngine.UI; // Needed for Text UI

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float maxHealth = 100f;     // total health
    public float damagePerHit = 1f;    // each bullet does this much damage

    [Header("UI Settings")]
    public Text healthText;            // Assign a UI Text element in the Inspector

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_bullet"))
        {
            TakeDamage(damagePerHit);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();

    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = $"Enemy Health: {currentHealth:0}";
        }
    }
}
