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
        left = 1f;
        period = 10f;
        LabyState.isKey1Passed = false;
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
            indicator.color = new Color(
               1f - indicator.fillAmount,
               indicator.fillAmount,
               0.3f
           );
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        LabyState.isKey1Passed = true;
        GameObject.Destroy(this.gameObject);
    }
}
