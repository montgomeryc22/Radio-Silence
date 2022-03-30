using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTD : MonoBehaviour
{
public float moveSpeed;
public bool isMoving;
public Vector2 input;

public void Update()
  {
    if (isMoving)
    {
      input.x = Input.GetAxis("Horizontal");
      input.y = Input.GetAxis("Vertical");

      if (input != Vector2.zero)
      {
        var targetPos = transform.position;
        targetPos.x += input.x;
        targetPos.y += input.y;

        StartCoroutine(Move(targetPos));
      }
    }
  }

  IEnumerator Move(Vector3 targetPos)
  {
    isMoving = true;

    while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
    {
      transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
      yield return null;
    }

    transform.position = targetPos;
    
    isMoving = false;
  }
}