using UnityEngine;

public class BulletPatternSpawnerFactory : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawner;

    public BulletSpawner Create(Transform parent, IBulletSpawnerMovement spawnerMovement, IBulletPattern bulletPattern)
    {
        var obj = Instantiate(bulletSpawner, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.SetParent(parent);
        var spawner = obj.GetComponent<BulletSpawner>();
        spawner.SetMovement(spawnerMovement);
        spawner.SetPattern(bulletPattern);
        return spawner;
    }
}
