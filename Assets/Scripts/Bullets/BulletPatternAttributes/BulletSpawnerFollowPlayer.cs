using UnityEngine;

public class BulletSpawnerFollowPlayer : IBulletPatternAttribute
{
    public BulletSpawnerFollowPlayer()
    {

    }

    public void Trigger(BulletSpawner bulletSpawner)
    {
        var player = bulletSpawner.playerTransform;
        Vector3 direction = player.transform.position - bulletSpawner.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletSpawner.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
