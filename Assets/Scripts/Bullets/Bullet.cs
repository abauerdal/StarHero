// Bullet.cs
// Simplified version for single bullet behavior
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public Vector3 direction = Vector3.right;
    public bool freezeRotation = false;
    public float spriteOffSet = 0;

    private float timer;

    void Start()
    {
        timer = lifetime;
    }

    void Update()
    {
        if (freezeRotation)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            transform.position += direction * speed * Time.deltaTime;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle + spriteOffSet);
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TriggerDestruction()
    {
        Destroy(gameObject);
    }
}

