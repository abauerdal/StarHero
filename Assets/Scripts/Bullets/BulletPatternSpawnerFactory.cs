using UnityEngine;

public class BulletPatternSpawnerFactory : MonoBehaviour
{
    [SerializeField] private GameObject bulletSpawner;
    [SerializeField] private GameObject aoeAttackSpawner;

    public BulletSpawner CreateBulletPattern(Transform parent, IBulletPatternAttribute[] attributes)
    {
        var obj = Instantiate(bulletSpawner, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.SetParent(parent);
        var spawner = obj.GetComponent<BulletSpawner>();
        spawner.SetAttributes(attributes);
        return spawner;
    }

    public AOEAttackSpawner CreateAOEPattern(Transform parent)
    {
        var obj = Instantiate(aoeAttackSpawner, new Vector3(0, 0, 0), Quaternion.identity);
        obj.transform.SetParent(parent);
        var spawner = obj.GetComponent<AOEAttackSpawner>();
        return spawner;
    }
}
