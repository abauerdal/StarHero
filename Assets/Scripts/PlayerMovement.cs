using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    public Animator playerAnimator;

    // Update is called once per frame
    void Update()
    {
        if (LevelHandler.instance.gameOverTriggered || LevelHandler.instance.pauseMenuOpen) { return; }
        //Set direction to the most recent movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }


        //If a key is lifted, but the opposing key is still being pressed, set movement to that direction
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.S))
            {
                MoveDown();
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveUp();
            }
        }

        //If no keys are being pressed, set movement to zerol
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            horizontalInput = 0;
            playerAnimator.SetBool("MovingLeft", false);
            playerAnimator.SetBool("MovingRight", false);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            verticalInput = 0;
        }

        transform.position += new
        Vector3(horizontalInput, verticalInput)
        * speed * Time.deltaTime;
    }

    private void MoveLeft()
    {
        horizontalInput = -1;
        playerAnimator.SetBool("MovingRight", false);
        playerAnimator.SetBool("MovingLeft", true);
    }

    private void MoveRight()
    {
        horizontalInput = 1;
        playerAnimator.SetBool("MovingLeft", false);
        playerAnimator.SetBool("MovingRight", true);
    }

    private void MoveUp()
    {
        verticalInput = 1;
    }

    private void MoveDown()
    {
        verticalInput = -1;
    }
}
