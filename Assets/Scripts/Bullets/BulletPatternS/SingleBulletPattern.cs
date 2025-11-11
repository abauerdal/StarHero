using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletPattern : IBulletPattern
{

    public void ApplyPattern(BulletSpawner bulletSpawner)
    {
        bulletSpawner.SpawnBullet(bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
}
