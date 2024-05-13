using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraAnchor;

    [SerializeField]
    private GameObject tankHead;

    private Vector3 cameraOffset;
    private Vector3 cameraAngels;
    private Vector3 initialAngles;
    private Vector3 initialOffset;

    void Start()
    {
        cameraOffset = this.transform.position - cameraAnchor.transform.position;
        cameraAngels = this.transform.eulerAngles;
        initialAngles = cameraAngels;
    }

    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        cameraAngels.y += mx;
        cameraAngels.x -= my;
        if (Input.GetKeyUp(KeyCode.V))
        {
            cameraOffset = (cameraOffset == Vector3.zero) ?
                initialOffset : Vector3.zero;
        }
    }

    void LateUpdate()
    {
        this.transform.position = cameraAnchor.transform.position +Quaternion.Euler(0,cameraAngels.y-initialAngles.y,0)* cameraOffset;
        this.transform.eulerAngles = cameraAngels;
        tankHead.transform.eulerAngles = cameraAngels;
    }
}
