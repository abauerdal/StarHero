using UnityEngine;

public class AOEAttack : MonoBehaviour
{
    public float lifetime;
    public float angle = 0;

    private float timer;

    void Start()
    {
        timer = lifetime;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
