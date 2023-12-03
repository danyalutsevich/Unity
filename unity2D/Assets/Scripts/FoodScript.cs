using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
	private float foodVelocity = 6f;
	void Start()
    {
        
    }

    void Update()
    {
		this.transform.Translate(foodVelocity * Time.deltaTime * Vector2.left);
	}
}
