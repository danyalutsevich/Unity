using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;


public class MenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;

    [SerializeField]
    TextMeshProUGUI timer;

    [SerializeField]
    Slider musicVolumeSlider;
    [SerializeField]
    Slider effectsVolumeSlider;
    [SerializeField]
    Toggle muteAllToggle;
    [SerializeField]
    AudioMixer soundMixer;


    void Start()
    {
        OnMusicVolumeChanged(musicVolumeSlider.value);
        OnEffectsVolumeChanged(effectsVolumeSlider.value);
        LabyState.isSoundsMuted = muteAllToggle.isOn;
        LabyState.isPaused = false;
    }

    void Update()    {

        if (!LabyState.isPaused)
        {

        TimeSpan t = TimeSpan.FromSeconds(Time.realtimeSinceStartup);

        timer.text = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}",
                        t.Hours,
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LabyState.isPaused = !LabyState.isPaused;
            if (LabyState.isPaused)
            {
                ShowMenu();
            }
            else
            {
                HideMenu();
            }
            canvas.SetActive(LabyState.isPaused);
        }


    }


    private void ShowMenu()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
        LabyState.isPaused = true;
    }

    private void HideMenu()
    {
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
        LabyState.isPaused = false;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        LabyState.musicVolume = volume;
        if (!LabyState.isSoundsMuted)
        {
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("MusicVolume", dB);
        }
    }

    public void OnEffectsVolumeChanged(float volume)
    {
        LabyState.effectsVolume = volume;
        if (!LabyState.isSoundsMuted)
        {
            float dB = -80f + 90f * volume;
            soundMixer.SetFloat("EffectsVolume", dB);
        }
    }

    public void OnMuteAllChanged(bool value)
    {
        LabyState.isSoundsMuted = value;
        if (value)
        {
            soundMixer.SetFloat("EffectsVolume", -80f);
            soundMixer.SetFloat("MusicVolume", -80f);
        }
        else
        {
            OnEffectsVolumeChanged(LabyState.effectsVolume);
            OnMusicVolumeChanged(LabyState.musicVolume);
        }
    }

    public void OnMenuButtonClick(int value)
    {
        switch (value)
        {
            case 1:  // Exit
                if (Application.isEditor)
                {
                    EditorApplication.ExitPlaymode();  
                }
                else                {
                    Application.Quit(0);
                }
                break;
            case 2:  // Defaults
                OnMusicVolumeChanged(0.5f);
                OnEffectsVolumeChanged(0.5f);
                OnMuteAllChanged(false);
                break;
            case 3:  // Close
                HideMenu();
                break;
            default:
                Debug.LogError($"Undefined button click detected: value '{value}'");
                break;
        }
    }
}
