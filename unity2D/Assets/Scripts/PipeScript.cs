using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
	private float pipeVelocity = 6f;

	void Start()
	{

	}

	void Update()
	{
		this.transform.Translate(pipeVelocity * Time.deltaTime * Vector2.left);

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Pipe Collision: " + collision.gameObject.name);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Pipe Collider: " + collision.gameObject.name);
	}
}
