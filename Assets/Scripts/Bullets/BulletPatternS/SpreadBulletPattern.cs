using System;
using UnityEngine;

public class SpreadBulletPattern : IBulletPattern
{
    int numberOfBullets;
    float radiusOfSpread;
    bool alternatingShots;
    public SpreadBulletPattern(int numberOfBullets, float radiusOfSpread, bool alternatingShots)
    {
        this.numberOfBullets = numberOfBullets;
        this.radiusOfSpread = radiusOfSpread;
        this.alternatingShots = alternatingShots;
    }

    public void ApplyPattern(BulletSpawner bulletSpawner)
    {
        var angleBetweenBullets = radiusOfSpread / (numberOfBullets - 1);
        float startAngle = -radiusOfSpread / 2f;
        var numberOfTimesToShoot = numberOfBullets;

        if((bulletSpawner.numberOfTimesShot % 2 == 1) && alternatingShots)
        {
            numberOfTimesToShoot--;
            startAngle += angleBetweenBullets / 2;
        }

        for (int i = 0; i < numberOfTimesToShoot; i++)
        {
            float angle = startAngle + (angleBetweenBullets * i);
            Quaternion rotation = bulletSpawner.transform.rotation * Quaternion.Euler(0, 0, angle);

            bulletSpawner.SpawnBullet(bulletSpawner.transform.position, rotation);
        }
    }
}
