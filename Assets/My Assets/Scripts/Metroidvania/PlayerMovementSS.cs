using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementSS : MonoBehaviour
{
    InputControls controls;

    public Rigidbody2D playerRB;
    public Animator animator;

    public Transform groundCheck;
    public LayerMask groundLayer;

    float direction = 0;
    public float speed = 8f;
    public bool isFacingRight = true;
    public float jumpForce = 5f;
    public float horizontal;

    bool isGrounded;
    int numberOfJumps = 0;



    private void Awake()
    {
        controls = new InputControls();
        controls.Enable();

        controls.Player.Movement.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Player.Jump.performed += ctx => Jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction >0 )
            Flip();
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
        }
        else
        {
            if(numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
      horizontal = context.ReadValue<Vector2>().x;
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
