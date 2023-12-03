using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    Rigidbody sphere;

    void Start()
    {
        sphere = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float av = Input.GetAxis("Vertical");
        float ah = Input.GetAxis("Horizontal");
        sphere.AddForce(Time.deltaTime * 1000 * new Vector3(ah, 0, av)); 
    }
}
