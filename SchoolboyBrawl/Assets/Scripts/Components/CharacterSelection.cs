using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [Header("Playable Characters")] 
    [SerializeField] private GameObject[] characters;
    [Header("Arrow control selection")] 
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject leftArrow;

    private int _selectedCharacter;
    
    void Start()
    {
        // hide all characters
        for (int i = 0; i < characters.Length; i++)
        {
            Debug.Log("Character name => " + characters[i].name);
            characters[i].SetActive(false);
        }
        // show only first character on list
        _selectedCharacter = 0;
        characters[_selectedCharacter].SetActive(true);
        // store in PlayerPrebs selected character
        // PlayerPrefs.SetInt("SelectedPlayer", _selectedCharacter);
        ArrowsControl(_selectedCharacter);
        Debug.Log("default player index => " + _selectedCharacter);
        Debug.Log("default player name => " + characters[_selectedCharacter].name);
    }

    public void PreviousCharacter()
    {
        Debug.Log("PreviousCharacter ");
        characters[_selectedCharacter].SetActive(false);
        _selectedCharacter--;
        ArrowsControl(_selectedCharacter);
        characters[_selectedCharacter].SetActive(true);
        Debug.Log("player name => " + characters[_selectedCharacter].name);
        Debug.Log("index " + _selectedCharacter);
    }

    public void NextCharacter()
    {
        Debug.Log("NextCharacter ");
        characters[_selectedCharacter].SetActive(false);
        _selectedCharacter++;
        ArrowsControl(_selectedCharacter);
        characters[_selectedCharacter].SetActive(true);
        Debug.Log("player name => " + characters[_selectedCharacter].name);
        Debug.Log("index " + _selectedCharacter);
    }

    private void ArrowsControl(int index)
    {
        leftArrow.SetActive(index <= 0 ? false : true);
        rightArrow.SetActive(index == characters.Length -1 ? false : true);
    }

    public void Test()
    {
        Debug.Log("Test ");
    }
    
    // TODO remove logs
}
