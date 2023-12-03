using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
	private float forceFactor = 300f;

	private Rigidbody2D body;

	void Start()
	{
		body = this.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			body.AddForce(Vector2.up * forceFactor);
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			body.AddTorque(forceFactor * 1);
			body.AddForce(Vector2.left * forceFactor);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			body.AddTorque(forceFactor * -1);
			body.AddForce(Vector2.right * forceFactor);
		}
	}
}
