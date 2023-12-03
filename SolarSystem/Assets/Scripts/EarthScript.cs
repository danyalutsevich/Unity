using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
	[SerializeField]
	private GameObject sun;

	private GameObject surface;
	private GameObject atmosphere;
	private float dayPeriod = 24f / 360f;
	private float skyPeriod = 12f / 360f;
	private float yearPeriod = 100f / 360f;


	void Start()
	{
		surface = GameObject.Find("EarthSurface");
		atmosphere = GameObject.Find("EarthAtmosphere");
		Debug.Log("Sun");
		Debug.Log(sun);
		Debug.Log("Surface");
		Debug.Log(surface);
		Debug.Log("Atmosphere");
		Debug.Log(atmosphere);
	}

	void Update()
	{
		surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod, Space.Self);
		atmosphere.transform.Rotate(Vector3.up, Time.deltaTime / skyPeriod);
		this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);
	}
}
