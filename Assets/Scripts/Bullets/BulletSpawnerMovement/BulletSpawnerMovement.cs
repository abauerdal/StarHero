using UnityEngine;

public class BulletSpawnerMovement : IBulletSpawnerMovement
{
    //Allow to trace back instead of reseting to first position
    //Allow to set new angles at each position reached
    //Allow setting different bullet fired values between each point
    Vector3[] positions;
    float bulletsFiredBetweenEachPoint;
    private int currentTarget;
    private int lastPosition;

    public BulletSpawnerMovement(Vector3[] positions, float bulletsFiredBetweenEachPoint)
    {
        this.positions = positions;
        this.bulletsFiredBetweenEachPoint = bulletsFiredBetweenEachPoint;
        currentTarget = 0;
        lastPosition = positions.Length - 1;
    }
    public void SpawnerMovement(BulletSpawner bulletSpawner)
    {
        //The actual distance between the last point and the target point
        float distanceToNextPoint = Vector3.Distance(positions[lastPosition], positions[currentTarget]);

        //Distance between bullets
        float distanceBetweenBullets = (distanceToNextPoint / bulletsFiredBetweenEachPoint);

        bulletSpawner.transform.position = Vector3.MoveTowards(
            bulletSpawner.transform.position,
            positions[currentTarget],
            distanceBetweenBullets
        );

        if (Vector3.Distance(bulletSpawner.transform.position, positions[currentTarget]) < 0.01f)
        {
            lastPosition = currentTarget;
            currentTarget++;

            if (currentTarget >= positions.Length)
            {
                currentTarget = 0;
            }
        }
    }
}
