using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameUILogic : MonoBehaviour
{
    private const string ResumeButtonName = "Resume";
    private const string SettingsButtonName = "Settings";
    private const string MenuButtonName = "Menu";
    private const string QuitButtonName = "Quit";

    public event EventHandler PauseMenuButtonPressed;

    protected virtual void OnPauseMenuButtonPressed()
    {
        PauseMenuButtonPressed?.Invoke(this, EventArgs.Empty);
    }
        
    private UIDocument _overlayDocument;

    private void OnEnable()
    {
        _overlayDocument = GetComponent<UIDocument>();

        _overlayDocument.rootVisualElement.Q<Button>(PauseMenuButtonName).clicked += () =>
        {
            Debug.Log("Pause Menu Button Pressed");
            OnPauseMenuButtonPressed();
        };
    }
}
}
