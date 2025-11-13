using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    public float bulletCooldown;
    float bulletTimer;
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Point where bullets spawn
    public float bulletSpeed; // Speed of the bullet

    void Start()
    {
        hp = startHp;
    }

    void Update()
    {
        bulletTimer -= Time.deltaTime;
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
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
        }
    }
}
