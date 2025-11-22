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
    public AudioClip explosionSound;

    public Slider playerHealthSlider;
    public Slider whammyBarSlider;

    public float invincibityFlashSpeed; //Must be less than invincibility time
    private float invincibityFlashTimer;

    private SpriteRenderer playerSprite;
    private Animator playerAnimator;

    int scrapePoints = 0;
    int maxScrapePoints = 100;

    public int damagePerHit = 1; 
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        hp = startHp;
        UpdateHealthUI();
        UpdateWhammyBar();
    }

    void Update()
    {
        invincibilityTimer -= Time.deltaTime;
        invincibityFlashTimer -= Time.deltaTime;

        if (hp != 0) { 
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
        else
        {
            AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("ShipDeath") && stateInfo.normalizedTime >= 1f)
            {
                playerSprite.enabled = false;
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
        if (col.CompareTag("EnemyBullet"))
        {
            col.GetComponent<Bullet>().TriggerDestruction();
            TakeDamage(damagePerHit);
            print(hp);
        }
        if (col.CompareTag("EnemyBeam"))
        {
            TakeDamage(damagePerHit);
            print(hp);
        }
    }

    void TakeDamage(int damage)
    {
        if (!isInvincible && !LevelHandler.instance.gameOverTriggered)
        {
            if (hp > 0)
            {
                hp -= damage;
            }
            UpdateHealthUI();
            if(hp != 0)
            {
                invincibilityTimer = invincibilityTime;
                SFXManager.instance.PlaySound(hurtSound, 0.5f);
            }
            isInvincible = true;
            if (hp <= 0)
            {
                playerAnimator.SetTrigger("PlayerDeath");
                SFXManager.instance.PlaySound(explosionSound, 1f);
                //gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
                LevelHandler.instance.TriggerGameOver();
            }
        }
    }

    public void ResetPlayer()
    {
        hp = startHp;
        isInvincible = false;
        invincibilityTimer = 0f;
        UpdateHealthUI();
        transform.position = new Vector3(0, -3, 0);
        playerSprite.enabled = true;
        playerAnimator.SetTrigger("PlayerRespawn");
    }

    void UpdateHealthUI()
    {
        if (playerHealthSlider != null)
        {
            playerHealthSlider.maxValue = startHp;
            playerHealthSlider.value = hp;
        }
    }

    public void AddScrapePoints(int points)
    {
        scrapePoints += points;
        UpdateWhammyBar();
    }

    void UpdateWhammyBar()
    {
        if (whammyBarSlider != null)
            whammyBarSlider.maxValue = maxScrapePoints;
            whammyBarSlider.value = scrapePoints;
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }
}
