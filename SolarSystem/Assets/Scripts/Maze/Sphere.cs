using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
	[SerializeField]
	GameObject anchorCamera;

	[SerializeField]
	Camera cam;

    Rigidbody sphere;
	Vector3 anchorOffset;


	void Start()
	{
		sphere = GetComponent<Rigidbody>();
		anchorOffset = anchorCamera.transform.position - this.transform.position;
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		float av = Input.GetAxis("Vertical");
		float ah = Input.GetAxis("Horizontal");

		Vector3 right = cam.transform.right;
		Vector3 forward = cam.transform.forward;

		forward.y = 0;
		forward = forward.normalized;

		Vector3 moveDirection = ah * right + av * forward;

		sphere.AddForce(Time.deltaTime * 1000 * moveDirection);
		anchorCamera.transform.position = anchorOffset + this.transform.position;
	}
}
