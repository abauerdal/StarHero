using UnityEngine;

public class BeamWarning : MonoBehaviour
{
    public float transparency;
    public float changeSpeed;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.color = new Color(1, 1, 1, transparency);
        transparency = Mathf.PingPong((Time.time) * changeSpeed, 1) + .3f;
    }
}
