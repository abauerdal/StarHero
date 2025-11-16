using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;

    public Vector3 target;

    public float effectOfCurve = 5f;

    private Vector3 moveDirection;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        moveDirection = transform.up;
    }

    void Update()
    {
        Vector3 directionToTarget = target - transform.position;

        //How close we are to the target on the Y axis
        float yProximity = Mathf.Max(0.1f, Mathf.Abs(target.y - transform.position.y));

        //Exponential angle the closer we are to the target
        float turnAngle = (effectOfCurve * Time.deltaTime) / yProximity;

        //Smoothly calculate direction based on the new angle and our current direction (This way we don't have to rotate the bullet and the sprite is locked in place)
        moveDirection = Vector3.Slerp(moveDirection, directionToTarget.normalized, turnAngle);

        transform.position += moveDirection * speed * Time.deltaTime;
    }

}
