using System;

using DG.Tweening;

using TMPro;

using UnityEngine;

public class ToogleButton : MonoBehaviour
{
    [SerializeField] private GameObject switchButton;
    [SerializeField] private TextMeshProUGUI text;

    private int _switchstate = 1;
    private bool _isFullScreen;

    void Start()
    {
        _switchstate = PlayerPrefs.GetInt("FullScreenMode", _switchstate);
        _isFullScreen = _switchstate < 0;
    }

    public void OnSwitchButton()
    {
        switchButton.transform.DOLocalMoveX(-switchButton.transform.localPosition.x, 0.2f);
        _switchstate = Math.Sign(-switchButton.transform.localPosition.x);
        Debug.Log("_switchstate => " + _switchstate);
        _isFullScreen = _switchstate < 0;
        Screen.fullScreen = _isFullScreen;
        SetText();

        // E2CD1F ON
        // E2781F OFF

        // AutoSaveFullScreenMode();
    }

    private void SetText()
    {
        Color32 newColor = _isFullScreen ? new Color32(226, 205, 31, 255) : new Color32(226, 120, 31, 255);
        text.text = _isFullScreen ? "ON" : "OFF";
        text.color = newColor;
    }

    private void AutoSaveFullScreenMode()
    {
        PlayerPrefs.SetInt("FullScreenMode", _switchstate);
        PlayerPrefs.Save();
    }

    // TODO anadir al script Settings
    // TODO eliminar Debug Log
}
