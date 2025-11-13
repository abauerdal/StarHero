using UnityEngine;

public class Level1Events : MonoBehaviour
{
    public LevelEventsHandler levelEventsHandler;
    public BulletPatternSpawnerFactory bulletPatternFactory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Direction 0 = right, 90 = up, 180 = left, 270 = down
    void Start()
    {
        float BARS_TO_SECONDS = 240f / 130f;

        levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
        {
            time = 1.0f,
            action = () => Debug.Log("Hit event at 1 second!")
        });

        levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
        {
            time = 0f,
            action = () =>
            {

                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerMovement(
                        new Vector3[]
                        {new Vector3(-1,0),
                        new Vector3(1,0)},
                        25),
                    new SingleBulletPattern()
                });
                    
                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = 0.1f;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 30f;
                */


                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SpreadBulletPattern(5, 20, false)
                });

                bulletSpawnerObject.transform.position = new Vector3(-9, 0);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS;
                bulletSpawner.bulletSpeed = 8f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 100f;

                bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(9, 0);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS;
                bulletSpawner.bulletSpeed = 8f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 100f;


                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new WaveBulletSpawnerMovemenet(30, 360, false), new SingleBulletPattern());
                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = 0.1f;
                bulletSpawner.bulletSpeed = 4f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 10f;
                */
            }
        });
    }
}
