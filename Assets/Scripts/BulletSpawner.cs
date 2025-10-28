// BulletSpawner.cs
// Simplified version for single bullet spawning with fixed rotation
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletResource;
    public float cooldown = 1f; // Time between shots
    public float bulletSpeed = 5f;
    public Vector2 bulletVelocity;
    public float rotation; // Fixed rotation for the bullet

    private float timer;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnBullet();
            timer = cooldown;
        }
    }

    public void SpawnBullet()
    {
        GameObject spawnedBullet = Instantiate(BulletResource, transform.position, Quaternion.Euler(0, 0, rotation));
        Bullet bullet = spawnedBullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.speed = bulletSpeed;
            bullet.velocity = bulletVelocity;
            bullet.rotation = rotation;
        }
    }
}

