using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    
    [SerializeField] private AudioMixer mainAudioMixer;
    [SerializeField] private Dropdown screenResolutionsDropdown;
    [SerializeField] private Dropdown graphicsQualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private Resolution[] _screenResolutions;

    void Start()
    {
        InitScreenResolutionsOptions();
    }

    private void InitScreenResolutionsOptions()
    {
        _screenResolutions = Screen.resolutions;
        screenResolutionsDropdown.ClearOptions();
        List<String> options = new List<String>();

        int currentScreenResolutionIndex = 0;
        var currenScreenResolution = Screen.currentResolution;
        for (int i = 0; i < _screenResolutions.Length; i++)
        {
            Resolution screenResolution = _screenResolutions[i];
            String option = screenResolution.width + " x " + screenResolution.height;
            options.Add(option);

            if (screenResolution.width == currenScreenResolution.width && screenResolution.height == currenScreenResolution.height)
            {
                currentScreenResolutionIndex = i;
            }
        }
        screenResolutionsDropdown.AddOptions(options);
        screenResolutionsDropdown.value = currentScreenResolutionIndex;
        screenResolutionsDropdown.RefreshShownValue();
    }

    private void InitGraphicsOptions()
    {
        
    }

    public void SetVolume(float volume)
    {
        mainAudioMixer.SetFloat("Volume", volume);
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetScreenResolution(int resolutionIndex)
    {
        Resolution screenResolution = _screenResolutions[resolutionIndex];
        Screen.SetResolution(screenResolution.width, screenResolution.height, Screen.fullScreen);
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        var text = fullScreenToggle.GetComponent<Text>();
        text.text = isFullScreen ? "ON" : "OFF";
    }
}
