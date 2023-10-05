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
    private const string ResetButtonName = "Reset";
    private const string MenuButtonName = "Menu";
    private const string QuitButtonName = "Quit";

    public event EventHandler ResumeButtonPressed;
    protected virtual void OnResumeButtonPressed()
    {
        ResumeButtonPressed?.Invoke(this, EventArgs.Empty);
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
        
        // Menu
        _pauseMenuDocument.rootVisualElement.Q<Button>(MenuButtonName).clicked += () =>
        {
            Debug.Log("Return to Menu");
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        };
        
        // Settings
        _pauseMenuDocument.rootVisualElement.Q<Button>(ResetButtonName).clicked += () =>
        {
            Debug.Log("Reset Game");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            Time.timeScale = 1f;
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
