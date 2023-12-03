using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
	[SerializeField]
	GameObject pipePrefab;

	[SerializeField]
	GameObject pipePrefabLong;

	[SerializeField]
	GameObject pipePrefabShort;

	[SerializeField]
	GameObject foodPrefab;

	//private float pipeSpawnPeriod = 4f;
	private float pipeCountdown;
	private float foodCountdown;
	private GameObject[] pipes;

	void Start()
	{
		pipes = new GameObject[] { pipePrefab, pipePrefabLong, pipePrefabShort };
		pipeCountdown = GameState.pipeSpawnPeriod;
		SpawnPipe();
		foodCountdown = pipeCountdown / 2f;
	}

	void Update()
	{
		pipeCountdown -= Time.deltaTime;
		if (pipeCountdown <= 0)
		{
			pipeCountdown = GameState.pipeSpawnPeriod;
			SpawnPipe();
		}

				SpawnFood();
		if (foodCountdown > 0)
		{
			if (foodCountdown - Time.deltaTime <= 0)
			{
			}
			foodCountdown -= Time.deltaTime;
		}
	}

	private void SpawnPipe()
	{
		Debug.Log("Pipe " + Random.value);
		var pipe = GameObject.Instantiate(pipes[Random.Range(0, pipes.Length)]);
		pipe.transform.position = transform.position + Vector3.up * Random.Range(-1.7f, 1.7f);
	}

	private void SpawnFood()
	{
		//Debug.Log("Food " + Random.value);
		var food = GameObject.Instantiate(foodPrefab);
		food.transform.position = transform.position + Vector3.up * Random.Range(-3.7f, 3.7f);
	}

}
