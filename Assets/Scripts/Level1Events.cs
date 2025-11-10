using UnityEngine;

public class Level1Events : MonoBehaviour
{
    public LevelEventsHandler levelEventsHandler;
    public GameObject BulletSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Direction 0 = right, 90 = up, 180 = left, 270 = down
    void Start()
    {
        levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
        {
            time = 1.0f,
            action = () => Debug.Log("Hit event at 1 second!")
        });

        levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
        {
            time = 5f,
            action = () =>
            {
                GameObject bulletSpawnerObject = Instantiate(BulletSpawner, new Vector3(0, 0, 0), Quaternion.identity);
                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Square;
                bulletSpawner.cooldown = 0.1f;
                bulletSpawner.bulletSpeed = 8f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.bulletPatternType = BulletPatternType.Spiral;
                bulletSpawner.direction = 0; // Right
                bulletSpawner.timeToLive = 10f;
                bulletSpawner.rotationSpeed = 180f;

                bulletSpawnerObject = Instantiate(BulletSpawner, new Vector3(0, 0, 0), Quaternion.identity);
                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Square;
                bulletSpawner.cooldown = 0.1f;
                bulletSpawner.bulletSpeed = 8f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.bulletPatternType = BulletPatternType.Spiral;
                bulletSpawner.direction = 180; // Left
                bulletSpawner.timeToLive = 10f;
                bulletSpawner.rotationSpeed = 180f;

                Debug.Log("5 seconds");
            }
        });
    }
}
