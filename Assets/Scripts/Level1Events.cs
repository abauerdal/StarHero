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
        float BEATS_TO_SECONDS = 60f / 130f;

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
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-5f, -1.25f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Needle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2; // higher number is more often shots.
                bulletSpawner.bulletSpeed = 8f; //self explanatory
                bulletSpawner.bulletLife = 5f; //despawn once offscreen, keep around 5f.
                bulletSpawner.direction = 90; //90 is facing down, 180 facing down, 270 facing left.
                bulletSpawner.timeToLive = 100f; //when to stop firing.
                bulletSpawner.freezeBulletRotation = false; //what do these last two do malcolm lol i forgot
                bulletSpawner.spriteOffSet = -45f; // ^
            }
        });

        levelEventsHandler.levelEvents.Add(new LevelEventsHandler.LevelEvent
        {
            time = 0f,
            action = () =>
            {
                //Single Bullet
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-5f, 1f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 0;
                bulletSpawner.timeToLive = 30f;

                bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(5f, 0f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 180;
                bulletSpawner.timeToLive = 30f;

                bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-5f, -1f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 0;
                bulletSpawner.timeToLive = 30f;

                bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(5f, -2f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 180;
                bulletSpawner.timeToLive = 30f;
                */

                //Single with movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerMovement(
                        new Vector3[]
                        {new Vector3(-4.8f,2),
                        new Vector3(4.8f,2)},
                        10),
                    new SingleBulletPattern()
                });


                bulletSpawnerObject.transform.position = new Vector3(-4.8f, 2f);


                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 16;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 30f;
                */

                //Single with scoped spin movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(8, 30, false),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(-5f, -1.25f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 4;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 0;
                bulletSpawner.timeToLive = 100f;

                bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(8, 30, false),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(5f, -1.25f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 4;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 180;
                bulletSpawner.timeToLive = 100f;
                */

                //Single with scoped spin movement (back and forth)
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(15, 180, true),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(0f, -4.5f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 32;
                bulletSpawner.bulletSpeed = 3f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Single with radial spin movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerSpin(32, 360, false),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(0f, -1.25f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 32;
                bulletSpawner.bulletSpeed = 2f;
                bulletSpawner.bulletLife = 5f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Spread no movement
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SpreadBulletPattern(5, 50, false)
                });

                bulletSpawnerObject.transform.position = new Vector3(2, -4.5f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 1f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;


                bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SpreadBulletPattern(5, 50, true)
                });

                bulletSpawnerObject.transform.position = new Vector3(-2, -4.5f);

                bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 1f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Radial Spread
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new SpreadBulletPattern(16, 360, true)
                });

                bulletSpawnerObject.transform.position = new Vector3(0, -1.25f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.BigCircle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2;
                bulletSpawner.bulletSpeed = 2f;
                bulletSpawner.bulletLife = 10f;
                bulletSpawner.direction = 90;
                bulletSpawner.timeToLive = 100f;
                */

                //Needle (no freeze bullet rotation & player follow)

                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SingleBulletPattern()
                });

                bulletSpawnerObject.transform.position = new Vector3(5f, -1.25f);

                BulletSpawner bulletSpawner = bulletSpawnerObject.GetComponent<BulletSpawner>();

                bulletSpawner.bulletShape = BulletShape.Needle;
                bulletSpawner.cooldown = BARS_TO_SECONDS / 2; // higher number is more often shots.
                bulletSpawner.bulletSpeed = 8f; //self explanatory
                bulletSpawner.bulletLife = 5f; //despawn once offscreen, keep around 5f.
                bulletSpawner.direction = 270;
                bulletSpawner.timeToLive = 100f;
                bulletSpawner.freezeBulletRotation = false;
                bulletSpawner.spriteOffSet = -45f;


                //Note Pattern (freeze bullet rotation)
                /*
                var bulletSpawnerObject = bulletPatternFactory.CreateBulletPattern(this.transform, new IBulletPatternAttribute[]
                {
                    new BulletSpawnerFollowPlayer(),
                    new SingleBulletPattern()
                });
                bulletSpawnerObject.transform.position = new Vector3(5f, -1.25f);
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

                //AOE ATTACK
                /*
                var aoeAttackSpawnerObject = bulletPatternFactory.CreateAOEPattern(this.transform);

                aoeAttackSpawnerObject.transform.position = new Vector3(0, -3);

                AOEAttackSpawner aoeAttackSpawner = aoeAttackSpawnerObject.GetComponent<AOEAttackSpawner>();

                aoeAttackSpawner.direction = 90;
                aoeAttackSpawner.warningDuration = BARS_TO_SECONDS;
                aoeAttackSpawner.attackDuration = BARS_TO_SECONDS / 2;
                aoeAttackSpawner.width = 2f;

                aoeAttackSpawnerObject = bulletPatternFactory.CreateAOEPattern(this.transform);

                aoeAttackSpawner = aoeAttackSpawnerObject.GetComponent<AOEAttackSpawner>();

                aoeAttackSpawner.direction = 0;
                aoeAttackSpawner.warningDuration = BARS_TO_SECONDS;
                aoeAttackSpawner.attackDuration = BARS_TO_SECONDS / 2;
                aoeAttackSpawner.width = 1f;
                */
            }
        });
    }
}
