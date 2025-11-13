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
                //Single Bullet
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-9.9f, 3);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 0;
                bulletSpawner.timeToLive = 30f;

                bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(3.3f, 1.5f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 180;
                bulletSpawner.timeToLive = 30f;

                bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-9.9f, 0);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 0;
                bulletSpawner.timeToLive = 30f;

                bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(3.3f, -1.5f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 180;
                bulletSpawner.timeToLive = 30f;
                */

                //Single with movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerMovement(
                        new Vector3[]
                        {new Vector3(-9.7f,3),
                        new Vector3(3.1f,3)},
                        12),
                    new SingleBulletPattern()
                });


                bulletSpawnerObject.transform.position = new Vector3(-9.9f, 3f);


                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 16;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 30f;
                */

                //Single with scoped spin movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(8, 30, false),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-9.9f, 0);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 4;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 0;
                bulletSpawner.timeToLive = 100f;

                bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(8, 30, false),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(3.3f, 0);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 4;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 180;
                bulletSpawner.timeToLive = 100f;
                */

                //Single with scoped spin movement (back and forth)
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(15, 180, true),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-3f, -4.9f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 32;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Single with radial spin movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(32, 360, false),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-3f, 0f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 32;
                bulletSpawner.bulletSpeed = 2f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Spread no movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SpreadBulletPattern(5, 50, false)
                });

                bulletSpawnerObject.transform.position = new Vector3(1, -4.9f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 1f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;


                bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SpreadBulletPattern(5, 50, true)
                });

                bulletSpawnerObject.transform.position = new Vector3(-6, -4.9f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 1f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Radial Spread
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new SpreadBulletPattern(16, 360, true)
                });

                bulletSpawnerObject.transform.position = new Vector3(-3, 0f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Circle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 2f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Needle (no freeze bullet rotation & player follow)
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(3.3f, 0);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Needle;
                bulletSpawner.cooldown = BARS_TO_SECONDS;
                bulletSpawner.bulletSpeed = 8f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 100f;
                bulletSpawner.freezeBulletRotation = false;
                bulletSpawner.spriteOffSet = -45f;
                */

                //Note Pattern (freeze bullet rotation)
                /*
                var bulletSpawnerObject = bulletPatternFactory.Create(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SingleBulletPattern()
                });
                bulletSpawnerObject.transform.position = new Vector3(3.3f, 0);
                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.NotePattern;
                bulletSpawner.cooldown = BARS_TO_SECONDS;
                bulletSpawner.bulletSpeed = 8f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 100f;
                bulletSpawner.freezeBulletRotation = true;
                bulletSpawner.spriteOffSet = 0;
                */
            }
        });
    }
}
