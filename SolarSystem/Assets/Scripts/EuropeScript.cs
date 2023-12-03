using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuropeScript : MonoBehaviour
{
	[SerializeField]
	private GameObject mars;
	[SerializeField]
	private GameObject sun;

	private float dayPeriod = 24f / 360f;
	private float monthPeriod = 12f / 360f;
	private float yearPeriod = 100f / 360f;

	private Vector3 moonAxis = Quaternion.Euler(0, 0, -30) * Vector3.up;

	void Start()
	{

	}

	void Update()
	{
		this.transform.Rotate(moonAxis, Time.deltaTime / dayPeriod);

		this.transform.RotateAround(mars.transform.position,
			moonAxis, Time.deltaTime / monthPeriod);

		this.transform.RotateAround(sun.transform.position,
			Vector3.up, Time.deltaTime / yearPeriod);
	}
}
