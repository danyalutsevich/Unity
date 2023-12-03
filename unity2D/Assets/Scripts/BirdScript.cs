using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
	[SerializeField]
	GameObject content;

	private Rigidbody2D bird;
	private float forceFactor = 100f;
	//private float vitalityTime = 3f;

	void Start()
	{
		bird = this.GetComponent<Rigidbody2D>();
		GameState.pipesPassed = 0;
		GameState.vitality = 0.85f;
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Space) || (GameState.isWkeyEnabled && Input.GetKeyDown(KeyCode.W)))
		{
			bird.AddForce(Vector2.up * forceFactor * 2.5f);
		}
		this.transform.eulerAngles = new Vector3(0, 0, bird.velocity.y * 3f);

		GameState.vitality -= Time.deltaTime / GameState.vitality;
		if (GameState.vitality <= 0)
		{
			GameState.vitality = 1;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Transform parent = collision.gameObject.transform.parent;

		if (parent != null && parent.CompareTag("Pipe"))
		{
			content.SetActive(true);
			Time.timeScale = 0;
			GameState.pipesPassed = 0;
		}
		if (parent.CompareTag("Food"))
		{
			Debug.Log("FOOOOOOOOOOOOOOD");
			GameState.vitality = 1f;
			GameObject.Destroy(collision.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Pipe"))
		{
			GameState.pipesPassed += 1;
		}

	}

}
