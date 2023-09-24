using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class ScenesUIManager : MonoBehaviour
{
    [SerializeField] private OverlayUILogic overlayUILogicPrefab;
    [SerializeField] private PauseGameUILogic _pauseGameUILogicPrefab;

    public OverlayUILogic _overlayPanel;
    private PauseGameUILogic _pauseMenuPanel;
    private float _timeScale;

    private void Awake()
    {
        _overlayPanel = Instantiate(overlayUILogicPrefab, transform);
        _pauseMenuPanel = Instantiate(_pauseGameUILogicPrefab, transform);
    }
    
    private void Start()
    {
        _pauseMenuPanel.gameObject.SetActive(false);
        _overlayPanel.gameObject.SetActive(true);
        _overlayPanel.PauseMenuButtonPressed += OnPauseMenuButtonPressed;
        _pauseMenuPanel.ResumeButtonPressed += OnResumeButtonPressed;
    }

    private void OnPauseMenuButtonPressed(object sender, EventArgs e)
    {
        _timeScale = Time.timeScale;
        Time.timeScale = 0f;
        _overlayPanel.gameObject.SetActive(false);
        _pauseMenuPanel.gameObject.SetActive(true);
    }

    private void OnResumeButtonPressed(object sender, EventArgs e)
    {
        Time.timeScale = _timeScale;
        _pauseMenuPanel.gameObject.SetActive(false);
        _overlayPanel.gameObject.SetActive(true);
    }

    
}
