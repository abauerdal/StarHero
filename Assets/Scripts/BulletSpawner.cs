// BulletSpawner.cs
// Simplified version for single bullet spawning with fixed rotation
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct BulletEntry
    {
        public BulletShape key;
        public GameObject prefab;
    }

    [Header("Assign bullet types and prefabs here")]
    public BulletEntry[] bulletEntries;

    public BulletShape bulletShape;
    public float cooldown; // Time between shots
    public float bulletSpeed;
    public float bulletLife;
    public BulletPatternType bulletPatternType; // Type of bullet pattern
    public float direction; // Fixed rotation for the bullet
    public float timeToLive;
    public float rotationSpeed;

    private float cooldownTimer;
    private float timeToLiveTimer;

    private Dictionary<BulletShape, GameObject> bulletDict;

    void Awake()
    {
        bulletDict = new Dictionary<BulletShape, GameObject>();

        foreach (var entry in bulletEntries)
        {
            bulletDict.Add(entry.key, entry.prefab);
        }
    }

    void Start()
    {
        cooldownTimer = cooldown;
        timeToLiveTimer = timeToLive;
        transform.rotation = Quaternion.Euler(0, 0, direction);
    }

    void Update()
    {
        timeToLiveTimer -= Time.deltaTime;
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            SpawnBullet();
            cooldownTimer = cooldown;
        }
        if (timeToLiveTimer <= 0)
        {
            Destroy(gameObject);
        }

        if (bulletPatternType == BulletPatternType.Spiral)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    public void SpawnBullet()
    {
        GameObject spawnedBullet = Instantiate(bulletDict[bulletShape], transform.position, Quaternion.identity);
        Bullet bullet = spawnedBullet.GetComponent<Bullet>();
        if (bullet != null)
        { 
            bullet.transform.rotation = transform.rotation;
            bullet.speed = bulletSpeed;
            bullet.direction = transform.right;
        }
    }
}

