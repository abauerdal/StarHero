// Bullet.cs
// Simplified version for single bullet behavior
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float rotation;
    public float lifetime = 5f;

    private float timer;

    void Start()
    {
        timer = lifetime;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    void Update()
    {
        transform.Translate(velocity.normalized * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

