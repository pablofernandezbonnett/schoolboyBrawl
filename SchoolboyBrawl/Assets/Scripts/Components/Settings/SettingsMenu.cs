using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioMixer mainAudioMixer;
    [SerializeField] private TMP_Dropdown screenResolutionsDropdown;
    [SerializeField] private TMP_Dropdown graphicsQualityDropdown;

    [Header("Panels")] 
    [SerializeField] private List<GameObject> panels;

    private Resolution[] _screenResolutions;
    private string[] _qualitySettings;
    private int _savedResolution;
    private int _savedGraphicsQuality;

    void Start()
    {
        // Load former saved settings
        _savedResolution = PlayerPrefs.GetInt("ScreenResolution", 0);
        _savedGraphicsQuality = PlayerPrefs.GetInt("GraphicsQuality", 2); // medium

        // Enable gameplay panel as default
        // Disable rest of panels
        TogglePanels(panels[0], panels);
        InitScreenResolutionsOptions();
        InitGraphicsOptions();
    }

    private void InitScreenResolutionsOptions()
    {
        _screenResolutions = Screen.resolutions;
        screenResolutionsDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        int currentScreenResolutionIndex = 0;
        var currenScreenResolution = Screen.currentResolution;
        for (int i = 0; i < _screenResolutions.Length; i++)
        {
            Resolution screenResolution = _screenResolutions[i];
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(screenResolution.width + " x " + screenResolution.height);
            options.Add(optionData);

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
        // Very Low
        // Low
        // Medium
        // High
        // Very High
        // Ultra
        _qualitySettings = QualitySettings.names;
        graphicsQualityDropdown.ClearOptions();
        int currentQualityIndex = 0;
        var currentQualityLevel = QualitySettings.GetQualityLevel();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < _qualitySettings.Length; i++)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(_qualitySettings[i]);
            options.Add(optionData);

            if (currentQualityLevel == i)
            {
                currentQualityIndex = i;
            }
        }
        graphicsQualityDropdown.AddOptions(options);
        graphicsQualityDropdown.value = currentQualityIndex;
        graphicsQualityDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        mainAudioMixer.SetFloat("Volume", volume);
    }

    public void SetGraphicsQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
        
        Debug.Log("Quality is =>" + qualityIndex + " " + _qualitySettings[qualityIndex]);
        
        PlayerPrefs.Save();
    }

    public void SetScreenResolution(int resolutionIndex)
    {
        Resolution screenResolution = _screenResolutions[resolutionIndex];
        Screen.SetResolution(screenResolution.width, screenResolution.height, Screen.fullScreen);
        
        PlayerPrefs.SetInt("ScreenResolution", resolutionIndex);

        Debug.Log("Resolution is =>" + screenResolution.width + " x " + screenResolution.height);
        
        PlayerPrefs.Save();
    }

    public void OnClickOnPanelName(GameObject panel)
    {
        Debug.Log("Panel => " + panel.name);
        TogglePanels(panel, panels);
    }

    private void TogglePanels(GameObject activePanel, List<GameObject> disabledPanel)
    {
        foreach (var panel in disabledPanel)
        {
            if (activePanel.name.Equals(panel.name))
            {
                EnablePanel(panel);
            }
            else
            {
                DisablePanel(panel);
            }
        }
    }
    
    private void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
    
    // TODO remove logs and TODOs
    // TODO put comments
}
