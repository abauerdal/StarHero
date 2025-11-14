using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer boundry;

    private float minX, maxX, minY, maxY;
    private float playerHalfWidth, playerHalfHeight;
    void Start()
    {
        playerHalfWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHalfHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        Bounds bounds = boundry.bounds;

        minX = bounds.min.x + playerHalfWidth;
        maxX = bounds.max.x - playerHalfWidth;

        minY = bounds.min.y + playerHalfHeight;
        maxY = bounds.max.y - playerHalfHeight;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, minX, maxX);
        playerPos.y = Mathf.Clamp(playerPos.y, minY, maxY);
        transform.position = playerPos;
    }
}
