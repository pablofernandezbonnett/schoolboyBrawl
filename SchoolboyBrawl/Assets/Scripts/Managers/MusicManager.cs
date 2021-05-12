using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
// the audio music clips for background music
    [SerializeField] private AudioClip[] audioClips;
    
    private AudioSource _myAudioSource;
    private float delayedTime = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusicHandler();
    }

    private void BackgroundMusicHandler()
    {
        _myAudioSource = GetComponent<AudioSource>();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Scene is Main menu Scene, play its audio clip
        // Not Main menu scene then current scene is a level, so play game level music
        if (currentSceneIndex == 0)
        {
            _myAudioSource.clip = audioClips[currentSceneIndex];
        }
        else
        {
            _myAudioSource.clip = audioClips[1];
        }
        // if there is already an audio clip been played
        // then when new clip starts playing
        // previous one gets stopped automatically
        _myAudioSource.PlayDelayed(delayedTime);
    }
}
