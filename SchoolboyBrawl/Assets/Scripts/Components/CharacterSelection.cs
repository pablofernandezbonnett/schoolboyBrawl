using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [Header("Playable Characters")] 
    [SerializeField] private GameObject[] characters;
    [Header("Arrow control selection")] 
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private GameObject leftArrow;

    public int SelectedCharacter { get; private set; }

    private CharacterInfo _characterInfo;

    void Start()
    {
        // hide all characters
        HideAllCharacters();
        // show only first character on list
        SelectedCharacter = 0;
        characters[SelectedCharacter].SetActive(true);
        // store in PlayerPrebs selected character
        // PlayerPrefs.SetInt("SelectedPlayer", SelectedCharacter);
        ArrowsControl(SelectedCharacter);
        Debug.Log("default player index => " + SelectedCharacter);
        Debug.Log("default player name => " + characters[SelectedCharacter].name);
        LoadCharacterInfo(characters[SelectedCharacter]);
    }

    private void HideAllCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            Debug.Log("Character name => " + characters[i].name);
            characters[i].SetActive(false);
        }
    }

    private void LoadCharacterInfo(GameObject selectedCharacter)
    {
        _characterInfo = FindObjectOfType<CharacterInfo>();
        _characterInfo.ShowAttributes(selectedCharacter);
    }
    
    public void PreviousCharacter()
    {
        Debug.Log("PreviousCharacter ");
        characters[SelectedCharacter].SetActive(false);
        SelectedCharacter--;
        ArrowsControl(SelectedCharacter);
        characters[SelectedCharacter].SetActive(true);
        Debug.Log("player name => " + characters[SelectedCharacter].name);
        Debug.Log("index " + SelectedCharacter);
        _characterInfo.ResetAttributeMeters();
        _characterInfo.ShowAttributes(characters[SelectedCharacter]);
    }

    public void NextCharacter()
    {
        Debug.Log("NextCharacter ");
        characters[SelectedCharacter].SetActive(false);
        SelectedCharacter++;
        ArrowsControl(SelectedCharacter);
        characters[SelectedCharacter].SetActive(true);
        Debug.Log("player name => " + characters[SelectedCharacter].name);
        Debug.Log("index " + SelectedCharacter);
        _characterInfo.ResetAttributeMeters();
        _characterInfo.ShowAttributes(characters[SelectedCharacter]);
    }

    private void ArrowsControl(int index)
    {
        leftArrow.SetActive(index <= 0 ? false : true);
        rightArrow.SetActive(index == characters.Length -1 ? false : true);
    }

    public GameObject[] GetCharacters()
    {
        return characters;
    }
    
    
    // TODO remove logs
}
