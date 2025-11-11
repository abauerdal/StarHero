using UnityEngine;

public class SpiralBulletSpawnerMovement : IBulletSpawnerMovement
{
    float rotationSpeed;
    public SpiralBulletSpawnerMovement(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }

    public void SpawnerMovement(BulletSpawner bulletSpawner)
    {
        bulletSpawner.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
