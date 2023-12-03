using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsScript : MonoBehaviour
{
	[SerializeField]
	private GameObject sun;

	private GameObject surface;
	private float dayPeriod = 24f / 360f;
	private float yearPeriod = 100f / 360f * 2f;


	void Start()
	{
		surface = GameObject.Find("MarsSurface");
		Debug.Log("Sun");
		Debug.Log(sun);
		Debug.Log("Surface");
		Debug.Log(surface);
		Debug.Log("Atmosphere");
	}

	void Update()
	{
		surface.transform.Rotate(Vector3.up, Time.deltaTime / dayPeriod, Space.Self);
		this.transform.RotateAround(sun.transform.position, Vector3.up, Time.deltaTime / yearPeriod);
	}
}
