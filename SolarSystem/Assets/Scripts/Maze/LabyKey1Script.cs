using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabyKey1Script : MonoBehaviour
{
    [SerializeField]
    Image indicator;
    private float period;
    private float left;



    void Start()
    {
        left = 1;
    }

    void Update()
    {
        left -= Time.deltaTime / period;

        if (left < 0)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            indicator.fillAmount = left;
        }

    }
}
