using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCamScript : MonoBehaviour
{
	[SerializeField]
	GameObject cameraAnchor;

	float camEulerX;
	float camEulerY;

	float ancEulerX;
	float ancEulerY;
	Vector3 rod;

	void Start()
	{
		camEulerX = this.transform.eulerAngles.x;
		camEulerY = this.transform.eulerAngles.y;
		ancEulerX = 0;
		ancEulerY = 0;
		rod = this.transform.position - cameraAnchor.transform.position;
	}

	void Update()
	{
		float mh = Input.GetAxis("Mouse X") * 8;
		float mv = Input.GetAxis("Mouse Y") * 8;


		if (camEulerX - mv >= 35 && camEulerX - mv <= 90)
		{
			camEulerX -= mv;
			ancEulerX -= mv;

		}

		camEulerY += mh;
		ancEulerY += mh;
	}

	void LateUpdate()
	{
		this.transform.eulerAngles = new Vector3(camEulerX, camEulerY, 0);

		this.transform.position = cameraAnchor.transform.position + Quaternion.Euler(ancEulerX, ancEulerY, 0) * rod;
	}
}
