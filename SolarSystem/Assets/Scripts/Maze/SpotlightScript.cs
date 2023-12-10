using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{

    [SerializeField]
    private GameObject cam;

    private Light spotLight;

    void Start()
    {
        this.spotLight = GetComponent<Light>();
        LabyState.spotLightIntensity = 1.5f;
    }

    void Update()
    {
        if (LabyState.isPaused) return;

        if (LabyState.firstPersonView && !LabyState.isDay)
        {
            LabyState.spotLightIntensity -= 0.0002f;
            this.transform.position = cam.transform.position;
            this.transform.forward = cam.transform.forward;
            spotLight.intensity = LabyState.spotLightIntensity;

            Vector2 wheel = Input.mouseScrollDelta;
            spotLight.enabled = true;
            if (wheel.y != 0)  // [25..90]
            {
                float spotAngle = spotLight.spotAngle + wheel.y;
                if (spotAngle < 25f)
                {
                    spotAngle = 25f;
                }
                else if (spotAngle > 90f)
                {
                    spotAngle = 90f;
                }
                if (spotLight.spotAngle != spotAngle)
                {
                    spotLight.spotAngle = spotAngle;
                }
            }
        }
        else
        {
            spotLight.enabled = false;
        }
    }
}
