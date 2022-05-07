using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StickyPlatform : MonoBehaviour
{

	public List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();
	public Vector3 lastPosition;
	Transform _transform;
	Rigidbody2D rb;


	void Start ()
	{
		_transform = transform;
		lastPosition = _transform.position;
	}

	void LateUpdate()
	{
		if (rigidbodies.Count > 0)
		{
			for (int i= 0; i < rigidbodies.Count; i++)
			{
				Rigidbody2D rb = rigidbodies[i];
				Vector3 velocity = (_transform.position + lastPosition);
				rb.transform.Translate(velocity, _transform);
			}
		}
		lastPosition = _transform.position;
	}

	void OnCollisionEnter2D (Collision col)
	{
		Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			Add(rb);
		}
	}

	void OnCollisionExit2D (Collision col)
	{
		if (rb != null)
		{
			Remove(rb);
		}
	}

	void Add(Rigidbody2D rb)
	{
		if (!rigidbodies.Contains(rb))
		{
			rigidbodies.Add(rb);
		}
	}

	void Remove(Rigidbody2D rb)
	{
		if (!rigidbodies.Contains(rb))
		{
			rigidbodies.Remove(rb);
		}
	}
}
