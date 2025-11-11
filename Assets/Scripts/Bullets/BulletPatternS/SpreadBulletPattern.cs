using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class SpreadBulletPattern : IBulletPattern
{
    int numberOfBullets;
    float radiusOfSpread;
    bool alternatingShots;

    public SpreadBulletPattern(int numberOfBullets, float radiusOfSpread, bool alternatingShots) {
        this.numberOfBullets = numberOfBullets;
        this.radiusOfSpread = radiusOfSpread;
        this.alternatingShots = alternatingShots;
    }

    public void ApplyPattern(BulletSpawner bulletSpawner)
    {
        
    }
}
