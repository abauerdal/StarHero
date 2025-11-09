using UnityEngine;
using UnityEngine.UI; 
public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    public float bulletCooldown;
    float bulletTimer;
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Point where bullets spawn
    public float bulletSpeed; // Speed of the bullet

    public Text playerHealthText;
    public Text WhammyBarText;

    int scrapePoints = 0;
    [HideInInspector] public bool wasHitThisFrame = false;

    public int damagePerHit = 1; 
    void Start()
    {
        hp = startHp;
        UpdateHealthText();
        UpdateWhammyBar();
    }

    void Update()
    {
        bulletTimer -= Time.deltaTime;

        wasHitThisFrame = false;
        /*
        if (Input.GetKey(KeyCode.Space) && bulletTimer <= 0)
        {
            Shoot();
            bulletTimer = bulletCooldown;
        }
        */
    }

    public void Shoot()
    {
        
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
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
        if (col.CompareTag("hostile") && bulletTimer <= 0)
        {
           
                TakeDamage(damagePerHit);
                print(hp);
                bulletTimer = bulletCooldown;
        }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        hp = Mathf.Clamp(hp, 0, startHp);
        UpdateHealthText();
        wasHitThisFrame = true;
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
}
