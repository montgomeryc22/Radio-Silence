using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlatform : MonoBehaviour
{
  private Collider2D _collider;
  private bool _playerOn;

  private void Start()
  {
    _collider = GetComponent<Collider2D>();
  }

  private void Update()
  {
    if (_playerOn && Input.GetAxisRaw("Vertical") < 0)
    {
      _collider.enabled = false;
      StartCoroutine(EnableCollider());
    }
  }

  private void SetPlayerOnPlatform (Collision2D coll, bool value)
  {
    var player = coll.gameObject.GetComponent<Player>();
    if (player != null)
    {
      _playerOn = value;
    }
  }

  private void OnCollisionEnter2D (Collision2D coll)
  {
    SetPlayerOnPlatform(coll, value:true);
  }
  private void OnCollisionExit2D (Collision2D coll)
  {
    SetPlayerOnPlatform(coll, value:true);
  }

  private IEnumerator EnableCollider()
  {
    yield return new WaitForSeconds(0.3f);
    _collider.enabled = true;
  }
}
