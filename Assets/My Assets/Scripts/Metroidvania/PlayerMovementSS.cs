using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementSS : MonoBehaviour {

  private Rigidbody2D rb;
  public float speed;
  public float jumpForce;
  public float moveInput;


  private bool isGrounded;
  public Transform feetPos;
  public float checkRadius;
  public LayerMask whatIsGround;

  private float jumpTimeCounter;
  public float jumpTime;
  private bool isJumping;

  void Start()
  {
      rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    moveInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
  }

  void Update()
  {
    isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

    // Flip character based on input.
    if(moveInput > 0)
    {
      transform.eulerAngles = new Vector3(0, 0, 0);
    } else if (moveInput < 0)
    {
      transform.eulerAngles = new Vector3(0, 180, 0);
    }

    // Snippet used for jump implementation.
    if(isGrounded == true && Input.GetButtonDown("Jump"))
    {
      isJumping = true;
      jumpTimeCounter = jumpTime;
      rb.velocity = Vector2.up * jumpForce;
    }

    if (Input.GetButtonDown("Jump") && isJumping == true)
    {
      if(jumpTimeCounter > 0)
      {
        rb.velocity = Vector2.up * jumpForce;
        jumpTimeCounter -= Time.deltaTime;
      } else
      {
        isJumping = false;
      }
    }

    if(Input.GetKeyUp(KeyCode.Space))
    {
      isJumping = false;
    }
  }
}
