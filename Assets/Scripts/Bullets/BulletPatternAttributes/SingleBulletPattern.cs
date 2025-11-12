using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletPattern : IBulletPatternAttribute
{

    public void Trigger(BulletSpawner bulletSpawner)
    {
        bulletSpawner.SpawnBullet(bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
}
