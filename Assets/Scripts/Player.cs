using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI; 
public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    public float invincibilityTime;
    float invincibilityTimer;
    private bool isInvincible = false;
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Point where bullets spawn
    public float bulletSpeed; // Speed of the bullet
    public AudioClip hurtSound;

    public Text playerHealthText;
    public Text WhammyBarText;

    public float invincibityFlashSpeed; //Must be less than invincibility time
    private float invincibityFlashTimer;

    private SpriteRenderer playerSprite;

    int scrapePoints = 0;

    public int damagePerHit = 1; 
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        hp = startHp;
        UpdateHealthText();
        UpdateWhammyBar();
    }

    void Update()
    {
        invincibilityTimer -= Time.deltaTime;
        invincibityFlashTimer -= Time.deltaTime;
        
        if (invincibilityTimer <= 0)
        {
            isInvincible = false;
            playerSprite.enabled = true; // Ensure sprite is visible after invincibility ends
        }
        else
        {
            if(invincibityFlashTimer <= 0)
            {
                playerSprite.enabled = !playerSprite.enabled;
                invincibityFlashTimer = invincibityFlashSpeed;
            }
        }
        
    }

    public void Shoot(Color bulletColor, Sprite bulletSprite)
    {
        
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
            bullet.GetComponent<Light2D>().color = bulletColor;
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90); // Rotate the bullet to face upwards
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.up * bulletSpeed; // Make the bullet move upwards
            }
            print("Bullet fired!");
        }
        else
        {
            Debug.LogWarning("BulletPrefab or BulletSpawnPoint is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("hostile") && !isInvincible)
        {
                col.GetComponent<Bullet>().TriggerDestruction(); ;
                TakeDamage(damagePerHit);
                print(hp);
                invincibilityTimer = invincibilityTime;
        }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, startHp);
        UpdateHealthText();
        isInvincible = true;
        SFXManager.instance.PlaySound(hurtSound, 0.5f);
    }

    void UpdateHealthText()
    {
        if (playerHealthText != null)
        {
            playerHealthText.text = $"Player Health: {hp}";
        }
    }

    public void AddScrapePoints(int points)
    {
        scrapePoints += points;
        UpdateWhammyBar();
    }

    void UpdateWhammyBar()
    {
        if (WhammyBarText != null)
            WhammyBarText.text = $"Whammy: {scrapePoints}";
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}
