using UnityEngine;

public class WaveBulletSpawnerMovemenet : IBulletSpawnerMovement
{
    int numberOfBulletsPerWave;
    float radiusOfWave;
    bool backAndForth;
    private int numberOfBulletsPerTwoWaves;
    private float startAngle;
    private float angleBetweenBullets;
    public WaveBulletSpawnerMovemenet(int numberOfBulletsPerWave, float radiusOfWave, bool backAndForth)
    {
        this.numberOfBulletsPerWave = numberOfBulletsPerWave;
        this.radiusOfWave = radiusOfWave;
        this.backAndForth = backAndForth;
        this.numberOfBulletsPerTwoWaves = numberOfBulletsPerWave + (numberOfBulletsPerWave - 2);
        this.startAngle = -radiusOfWave / 2f;
        this.angleBetweenBullets = radiusOfWave / (numberOfBulletsPerWave - 1);
    }

    public void SpawnerMovement(BulletSpawner bulletSpawner)
    {
        if (bulletSpawner.numberOfTimesShot == 0)
        {
            bulletSpawner.transform.rotation = bulletSpawner.transform.rotation * Quaternion.Euler(0, 0, startAngle);
        }

        bool waveIsOnTheWayBack = false;
        int bulletsFiredOnThisWave;
        if (backAndForth)
        {
            bulletsFiredOnThisWave = bulletSpawner.numberOfTimesShot % numberOfBulletsPerTwoWaves;
            waveIsOnTheWayBack = (bulletsFiredOnThisWave - numberOfBulletsPerWave) >= 0;
        }
        else
        {
            if(radiusOfWave == 360) { 
                bulletsFiredOnThisWave = bulletSpawner.numberOfTimesShot % (numberOfBulletsPerWave - 1);
            }
            else
            {
                bulletsFiredOnThisWave = bulletSpawner.numberOfTimesShot % numberOfBulletsPerWave;
            }
        }


        if (!waveIsOnTheWayBack)
        {
            float angle = startAngle + (angleBetweenBullets * bulletsFiredOnThisWave);
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, bulletSpawner.direction) * Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = -startAngle - (angleBetweenBullets * (bulletsFiredOnThisWave - (numberOfBulletsPerWave - 1)));
            bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, bulletSpawner.direction) * Quaternion.Euler(0, 0, angle);
        }
    }
}
