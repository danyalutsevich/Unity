using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	[SerializeField]
	GameObject sun;

	float camAngleX;
	float camAngleY;

	float camSunAngleX;
	float camSunAngleY;

	Vector3 camSun;

	Camera cam;

	void Start()
	{
		camAngleX = transform.eulerAngles.x;
		camAngleY = transform.eulerAngles.y;
		camSun = this.transform.position - sun.transform.position;
		camSunAngleX = camAngleY = 0;
		cam = GetComponent<Camera>();
	}

	void Update()
	{
		float mx = Input.GetAxis("Mouse X") * 10;
		float my = Input.GetAxis("Mouse Y") * 10;

		camAngleX -= my;
		camAngleY += mx;

		if (Input.GetKey(KeyCode.LeftShift))
		{
			Cursor.lockState = CursorLockMode.Locked;
			camSunAngleX -= my;
			camSunAngleY += mx;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
		}

	}

	private void LateUpdate()
	{
		this.transform.eulerAngles = new Vector3(camAngleX, camAngleY, 0);
		this.transform.position = sun.transform.position + Quaternion.Euler(camSunAngleX, camSunAngleY, 0) * camSun;
		Vector2 wheel = Input.mouseScrollDelta;

		if (wheel != Vector2.zero)
		{
			var fov = cam.fieldOfView + wheel.y;

			if (fov >= 5 && fov <= 120)
			{
				cam.fieldOfView = fov;
			}
		}
		if (Input.GetKey(KeyCode.LeftControl))
		{
			this.transform.Translate(
				Time.deltaTime * this.transform.forward * Input.GetAxis("Vertical") +
					Time.deltaTime * this.transform.right * Input.GetAxis("Horizontal")
				);
			camSun = this.transform.position - sun.transform.position;

		}

		//this.transform.Rotate(-my*10, mx*10, 0);
	}
}
