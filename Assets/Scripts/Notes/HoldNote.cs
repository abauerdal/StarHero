using UnityEngine;

public class HoldNote : MonoBehaviour
{
    public bool pressed = false;
    public bool completed = false;

    Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = new Vector2(0, -speed);
    }

}