using System;
using DG.Tweening;
using UnityEngine;

public class ToogleButton : MonoBehaviour
{
    [SerializeField] private GameObject switchButton;
    
    private int _switchstate = 1;
    private bool _isFullScreenMode;
    
    void Start()
    {
        _isFullScreenMode = _switchstate > 0;
    }

    public void OnSwitchButton()
    {
        switchButton.transform.DOLocalMoveX(-switchButton.transform.localPosition.x, 0.2f);
        _switchstate = Math.Sign(-switchButton.transform.localPosition.x);
        Debug.Log("_switchstate => " + _switchstate);
        _isFullScreenMode = _switchstate > 0;
        Screen.fullScreen = _isFullScreenMode;
    }
    
    // TODO anadir al script Settings
    // TODO eliminar Debug Log
}
