using UnityEngine;

public class BulletPatternSpawnerFactory : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawner;

    public BulletSpawner Create(Transform parent, IBulletPatternAttribute[] attributes)
    {
        var obj = Instantiate(bulletSpawner, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.SetParent(parent);
        var spawner = obj.GetComponent<BulletSpawner>();
        spawner.SetAttributes(attributes);
        return spawner;
    }
}
