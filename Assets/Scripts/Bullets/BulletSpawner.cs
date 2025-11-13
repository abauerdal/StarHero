// BulletSpawner.cs
// Simplified version for single bullet spawning with fixed rotation
using System;
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
    private IBulletPatternAttribute[] bulletPatternAttributes;
    public float direction; // Fixed rotation for the bullet
    public float timeToLive;
    public int numberOfTimesShot = 0;
    private double deathTimeDSP;
    public Transform playerTransform;
    public bool freezeBulletRotation;
    public float spriteOffSet;

    double songTimeAtCreation;

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
        songTimeAtCreation = LevelEventsHandler.songTime;
        deathTimeDSP = songTimeAtCreation + timeToLive;
        transform.rotation = Quaternion.Euler(0, 0, direction);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.rotation * Vector3.right, Color.red);
        double currentSongTime = LevelEventsHandler.songTime;
        double nextShotTime = songTimeAtCreation + (numberOfTimesShot * cooldown);

        if (currentSongTime >= nextShotTime)
        {
            foreach (var bulletPatternAttribute in bulletPatternAttributes)
            {
                bulletPatternAttribute.Trigger(this);
            }
            numberOfTimesShot++;
        }
        if (currentSongTime >= deathTimeDSP)
        {
            Destroy(gameObject);
        }
    }

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        GameObject spawnedBullet = Instantiate(bulletDict[bulletShape], position, Quaternion.identity);
        Bullet[] bullets = spawnedBullet.GetComponentsInChildren<Bullet>();
        if (bullets != null && bullets.Length > 0)
        {
            foreach (var bullet in bullets)
            {
                bullet.direction = rotation * Vector3.right;
                bullet.speed = bulletSpeed;
                bullet.lifetime = bulletLife;
                bullet.freezeRotation = freezeBulletRotation;
                bullet.spriteOffSet = spriteOffSet;
            }

        }
    }

    public void SetAttributes(IBulletPatternAttribute[] attributes)
    {
        this.bulletPatternAttributes = attributes;
    }
}

