using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseGameUILogic : MonoBehaviour
{
    private const string ResumeButtonName = "Resume";
    private const string SettingsButtonName = "Settings";
    private const string MenuButtonName = "Menu";
    private const string QuitButtonName = "Quit";

    public event EventHandler ResumeButtonPressed;
    public event EventHandler SettingsButtonPressed;
    protected virtual void OnResumeButtonPressed()
    {
        ResumeButtonPressed?.Invoke(this, EventArgs.Empty);
    }
    
    protected virtual void OnSettingsButtonPressed()
    {
        SettingsButtonPressed?.Invoke(this, EventArgs.Empty);
    }
    
    private UIDocument _pauseMenuDocument;

    private void OnEnable()
    {
        _pauseMenuDocument = GetComponent<UIDocument>();
        
        // Resume
        _pauseMenuDocument.rootVisualElement.Q<Button>(ResumeButtonName).clicked += () =>
        {
            Debug.Log("Resume with game");
            OnResumeButtonPressed();
        };
        
        // Settings
        _pauseMenuDocument.rootVisualElement.Q<Button>(SettingsButtonName).clicked += () =>
        {
            Debug.Log("Settings menu open");
            OnSettingsButtonPressed();
        };
        
        // Quit
        _pauseMenuDocument.rootVisualElement.Q<Button>(QuitButtonName).clicked += () =>
        {
            Debug.Log("Quit Button Clicked");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        };
    }
}
