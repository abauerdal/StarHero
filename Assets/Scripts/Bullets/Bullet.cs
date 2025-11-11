// Bullet.cs
// Simplified version for single bullet behavior
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float lifetime = 5f;

    private float timer;

    void Start()
    {
        timer = lifetime;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

