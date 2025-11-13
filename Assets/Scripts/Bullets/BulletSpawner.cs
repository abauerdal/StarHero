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
    private IBulletPatternAttribute[] bulletPatternAttributes;
    public float direction; // Fixed rotation for the bullet
    public float timeToLive;
    public int numberOfTimesShot = 0;
    private double deathTimeDSP;

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
    }

    void Update()
    {
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
        GameObject spawnedBullet = Instantiate(bulletDict[bulletShape], position, rotation);
        Bullet bullet = spawnedBullet.GetComponent<Bullet>();
        if (bullet != null)
        { 
            bullet.speed = bulletSpeed;
            bullet.lifetime = bulletLife;
        }
    }

    public void SetAttributes(IBulletPatternAttribute[] attributes)
    {
        this.bulletPatternAttributes = attributes;
    }
}

