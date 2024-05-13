using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tank"))
        {
            State.shellCount++;
            Destroy(gameObject);
            Debug.Log(State.shellCount);
        }

    }

   
}
