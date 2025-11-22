using UnityEngine;
using UnityEngine.UI; // Needed for Text UI

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float damagePerHit = 1f;    // each bullet does this much damage

    [Header("UI Settings")]
    public Slider healthSlider;            // Assign a UI Text element in the Inspector

    private float currentHealth;
    public AudioClip enemyDefeatSound;

    void Start()
    {
        healthSlider.maxValue = NoteSpawner.totalNotes;
        currentHealth = NoteSpawner.totalNotes;
        UpdateHealthUI();
    }

    private void Update()
    {
        if (currentHealth <= 0) {
            transform.Translate(new Vector3(0, 0.5f * Time.deltaTime, 0));
        }
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
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                SFXManager.instance.PlaySound(enemyDefeatSound, 1f);
                LevelHandler.instance.TriggerLevelEnd();
            }
            UpdateHealthUI();
        }
    }

    public void ResetEnemy()
    {
        currentHealth = NoteSpawner.totalNotes;
        UpdateHealthUI();
        transform.position = new Vector3(0, 3.2f, 0);
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }

}
