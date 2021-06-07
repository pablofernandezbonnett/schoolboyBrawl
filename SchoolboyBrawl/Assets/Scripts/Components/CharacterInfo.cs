using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{

    [Header("Attributes Meter")] 
    [SerializeField] private GameObject strength;
    [SerializeField] private GameObject speed;
    [SerializeField] private GameObject agility;
    [SerializeField] private GameObject power;

    private CharacterSelection _characterSelectionScript;
    private int _selectedCharacterIndex;
    private GameObject[] _characters;
    private GameObject _selectedCharacter;

    private Image[] strengthMeter;
    private Image[] speedMeter;
    private Image[] agilityMeter;
    private Image[] powerMeter;
        
    void Start()
    {
        InitSetup();
        ShowAttributes(_selectedCharacter);
    }

    private void InitSetup()
    {
        _characterSelectionScript = FindObjectOfType<CharacterSelection>();
        _selectedCharacterIndex = _characterSelectionScript.SelectedCharacter;
        _characters = _characterSelectionScript.GetCharacters();
        _selectedCharacter = _characters[_selectedCharacterIndex];

        strengthMeter = strength.GetComponentsInChildren<Image>();
        speedMeter = speed.GetComponentsInChildren<Image>();
        agilityMeter = agility.GetComponentsInChildren<Image>();
        powerMeter = power.GetComponentsInChildren<Image>();

        ResetAttributeMeters();
    }
    
    public void ShowAttributes(GameObject character)
    {
        int[] attributes = GetAttributes(character.name);
        EnableImageComponentInChildren(strengthMeter, attributes[0]);
        EnableImageComponentInChildren(speedMeter, attributes[1]);
        EnableImageComponentInChildren(agilityMeter, attributes[2]);
        EnableImageComponentInChildren(powerMeter, attributes[3]);
    }
    
    private int[] GetAttributes(string name)
    {
        int[] attributes;
        if ("Player Boy".Equals(name))
        {
            attributes = new[] {3, 1, 2, 3};
        }
        else
        {
            attributes = new[] {2, 2, 2, 2};
        }
        return attributes;
    }

    public void ResetAttributeMeters()
    {
        DisableImageComponentInChildren(strengthMeter);
        DisableImageComponentInChildren(speedMeter);
        DisableImageComponentInChildren(agilityMeter);
        DisableImageComponentInChildren(powerMeter);
    }
    
    private void DisableImageComponentInChildren(Image[] children)
    {
        foreach (var item in children)
        {
            item.gameObject.SetActive(false);
        }
    }
    
    private void EnableImageComponentInChildren(Image[] children, int attributeValue)
    {
        for (int i = 0; i < children.Length && i < attributeValue; i++)
        {
            children[i].gameObject.SetActive(true);
        }
    }
    
    // TODO improve
}
