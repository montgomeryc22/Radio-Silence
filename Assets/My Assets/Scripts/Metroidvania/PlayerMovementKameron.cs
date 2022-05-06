using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovementKameron : MonoBehaviour {
  [SerializeField]
  LayerMask lmWalls;
  [SerializeField]
  float fJumpVelocity = 5;

  Rigidbody2D rb;
  private bool isGrounded;
  public Transform feetPos;
  public float checkRadius;
  public LayerMask whatIsGround;

  public SpriteRenderer sprite;
  GameObject FrontSpace;

  float fJumpPressedRemember = 0;
  [SerializeField]
  float fJumpPressedRememberTime = 0.2f;

  float fGroundedRemember = 0;
  [SerializeField]
  float fGroundedRememberTime = 0.25f;

  [SerializeField]
  float fHorizontalAcceleration = 1;
  [SerializeField]
  [Range(0, 1)]
  float fHorizontalDampingBasic = 0.5f;
  [SerializeField]
  [Range(0, 1)]
  float fHorizontalDampingWhenStopping = 0.5f;
  [SerializeField]
  [Range(0, 1)]
  float fHorizontalDampingWhenTurning = 0.5f;

  [SerializeField]
  [Range(0, 1)]
  float fCutJumpHeight = 0.5f;

  void Start ()
  {
      rb = GetComponent<Rigidbody2D>();
  }

void Update ()
  {
 	isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
      Vector2 v2GroundedBoxCheckPosition = (Vector2)transform.position + new Vector2(0, -0.01f);
      Vector2 v2GroundedBoxCheckScale = (Vector2)transform.localScale + new Vector2(-0.02f, 0);
      bool bGrounded = Physics2D.OverlapBox(v2GroundedBoxCheckPosition, v2GroundedBoxCheckScale, 0, lmWalls);

      if (Input.GetAxisRaw("Horizontal") > 0)
      {
        sprite.flipX = false;
      } else if (Input.GetAxisRaw("Horizontal") < 0)
      {
        sprite.flipX = true;
      }

      fGroundedRemember -= Time.deltaTime;
      if (bGrounded)
      {
          fGroundedRemember = fGroundedRememberTime;
      }

      fJumpPressedRemember -= Time.deltaTime;
      if (Input.GetButtonDown("Jump"))
      {
          fJumpPressedRemember = fJumpPressedRememberTime;
      }

      if (Input.GetButtonUp("Jump"))
      {
          if (rb.velocity.y > 0)
          {
              rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * fCutJumpHeight);
          }
      }

      if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0))
      {
          fJumpPressedRemember = 0;
          fGroundedRemember = 0;
          rb.velocity = new Vector2(rb.velocity.x, fJumpVelocity);
      }

      float fHorizontalVelocity = rb.velocity.x;
      fHorizontalVelocity += Input.GetAxisRaw("Horizontal");

      if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f)
          fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f);
      else if (Mathf.Sign(Input.GetAxisRaw("Horizontal")) != Mathf.Sign(fHorizontalVelocity))
          fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenTurning, Time.deltaTime * 10f);
      else
          fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f);

      rb.velocity = new Vector2(fHorizontalVelocity, rb.velocity.y);
  }
}
