using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("Collision: " + collision.gameObject.name);
		if (collision.gameObject?.transform?.parent?.gameObject != null)
		{
			GameObject.Destroy(collision.gameObject.transform.parent.gameObject);
		}
	}

}
