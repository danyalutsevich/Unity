using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyLightScript : MonoBehaviour
{

    #region isDay prop
    private bool _isDay;
    private bool isDay
    {
        get => _isDay;
        set
        {
            LabyState.isDay = _isDay = value;
            if (_isDay) SetDayLighting();
            else SetNightLighting();
        }
    }
    #endregion

    private Light lightComponent;

    void Start()
    {
        lightComponent = this.GetComponent<Light>();
        isDay = true;
    }

    void Update()
    {
        if (LabyState.isPaused) return;

        if (Input.GetKeyUp(KeyCode.N))
        {
            isDay = !isDay;
            LabyState.spotLightIntensity = 1.5f;

        }
    }
    private void SetDayLighting()
    {
        lightComponent.intensity = 1f;
        RenderSettings.skybox.SetFloat("_Exposure", 1f);
    }
    private void SetNightLighting()
    {
        lightComponent.intensity = .05f;
        RenderSettings.skybox.SetFloat("_Exposure", .05f);
    }
}
