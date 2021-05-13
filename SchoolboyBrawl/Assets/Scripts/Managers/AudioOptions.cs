using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{

    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;
    
    void Start()
    {
        // Player Preferences
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 75);
        effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 75);
    }

    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        Debug.Log("NEW Music Volume " + musicVolumeSlider.value);
    }
    
    public void SetEffectsVolume()
    {
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolumeSlider.value);
        Debug.Log("NEW Effects Volume " + effectsVolumeSlider.value);
    }
    
    // TODO on press BACK button, save preferences
}
