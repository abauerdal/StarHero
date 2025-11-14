using UnityEngine;

public class Note : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = new Vector2(0, -speed);
    }
}
